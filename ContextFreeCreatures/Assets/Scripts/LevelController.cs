using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelController : MonoBehaviour
{
    GameObject cam;
    public GameObject spriteBackground;

    public GameObject startNode;

    public GameObject hint;
    public Canvas canvas;

    private List<float> posWidths = new List<float>();

    private GameObject treeArea;
    private RectTransform rectTransform;

    float treeSpaceWidth;
    float treeSpaceHeight;
    private float maxRows = 6;

    private List<List<GameObject>> tree = new List<List<GameObject>>();

    private float timeElapsed = 0f;
    private int numberOfNodesUsed = 0;

    public bool isLevelEnd = false;

    public Text noOfLives;

    int noOfFails;

    float maxWidth;

    private void Start() 
    {
        noOfFails = GetLevelFails();
        if (noOfFails > 1)
            hint.SetActive(true);
        else
            hint.SetActive(false);

        DataToCSV.AddNewLevelLine(StaticVariables.Level.ToString());
        treeArea = GameObject.Find("TreeSpace");
        cam = GameObject.Find("Main Camera");
        rectTransform = (RectTransform)treeArea.transform;
        treeSpaceWidth = rectTransform.rect.width;
        treeSpaceHeight = rectTransform.rect.height;
        timeElapsed = Time.time;
        noOfLives.GetComponent<Text>().text = PlayerPrefs.GetInt("Lives").ToString();
        StaticVariables.NoOfLives = PlayerPrefs.GetInt("Lives");
        if (StaticVariables.Level > 0)
            cam.GetComponent<MusicControl>().SetSliderValue(StaticVariables.VolumeLevel);

        maxWidth = treeSpaceWidth;
    }

    public void ReplaceNode(GameObject creatureImage, Vector3 node)
    {
        this.GetComponent<ScaleViewport>().contentScaler.transform.DetachChildren();
        GameObject bkg = Instantiate(spriteBackground, canvas.transform);
        bkg.GetComponent<RectTransform>().transform.position = node;
        bkg.transform.SetParent(treeArea.transform);
        bkg.SetActive(true);

        GameObject creature = Instantiate(creatureImage, canvas.transform);
        creature.GetComponent<RectTransform>().transform.position = node;
        creature.transform.SetParent(treeArea.transform);
        creature.SetActive(true);

        numberOfNodesUsed += 1;
        treeArea.transform.SetParent(this.GetComponent<ScaleViewport>().contentScaler.transform);

    }

    public void GetContents(List<GameObject> ruleImages, GameObject prevNode, float prevNodeY)
    {
        this.GetComponent<ScaleViewport>().contentScaler.transform.DetachChildren();

        int imageCount = ruleImages.Count;
        List<GameObject> ruleObjects = new List<GameObject>();

        float splitHeight = treeSpaceHeight/maxRows;
        float startHeight = prevNodeY;
        startHeight = RemapRange(startHeight, -treeSpaceHeight/2, treeSpaceHeight/2,  0, treeSpaceHeight);
        float height = startHeight - splitHeight;

        float splitWidth = 0;
        float startWidth = 0f;

        float prevNodeX = prevNode.GetComponent<RectTransform>().transform.localPosition.x;

        if (prevNode == startNode)
        {
            float nodeX = RemapRange(prevNodeX, -treeSpaceWidth/2, treeSpaceWidth/2, 0, treeSpaceWidth);
            startWidth = -treeSpaceWidth/(imageCount*2);
            splitWidth = (treeSpaceWidth + (treeSpaceWidth/imageCount))/(imageCount + 1);
            startWidth = nodeX - (splitWidth/imageCount);
        }
        else
        {
            if (ruleImages.Count == 1)
                startWidth = RemapRange(prevNodeX, -treeSpaceWidth/2, treeSpaceWidth/2, 0, treeSpaceWidth);
            else
            {
                float nodeNeighX = treeSpaceWidth/2;

                for (int i = 0; i < tree.Count; i++)
                {
                    for (int j = 0; j < tree[i].Count; j++)
                    {
                        if (tree[i][j] == prevNode)
                            {
                                if (j == 0)
                                {
                                    nodeNeighX = RemapRange(tree[i][j+1].transform.localPosition.x, -treeSpaceWidth/2, treeSpaceWidth/2, 0, treeSpaceWidth);
                                    break;
                                }
                                else 
                                {
                                    nodeNeighX = RemapRange(tree[i][j-1].transform.localPosition.x, -treeSpaceWidth/2, treeSpaceWidth/2, 0, treeSpaceWidth);        
                                    break;
                                }                    
                            }
                    }
                }


                float nodeX = RemapRange(prevNodeX, -treeSpaceWidth/2, treeSpaceWidth/2, 0, treeSpaceWidth);
                float newWidth = Mathf.Abs(nodeNeighX - nodeX) - 150;

                if (ruleImages.Count > 2)
                    splitWidth = (newWidth/(imageCount-1));
                else
                    splitWidth = newWidth;
                startWidth = nodeX - (newWidth/2);

                if (startWidth < 0)
                {
                    this.GetComponent<ScaleViewport>().ScaleTreeSize(maxWidth + (Mathf.Abs(startWidth)*2) + 100f, treeSpaceHeight, 0);
                    maxWidth = maxWidth + (Mathf.Abs(startWidth)*2) + 100f;
                }

            }
        }

        for (int i = 0; i < ruleImages.Count; i++)
        {
            float x = RemapRange(startWidth, 0, treeSpaceWidth, -treeSpaceWidth/2, treeSpaceWidth/2);

            float y = RemapRange(height, 0, treeSpaceHeight, -treeSpaceHeight/2, treeSpaceHeight/2);
            
            GameObject gemClone = Instantiate(ruleImages[i], canvas.transform);
            gemClone.transform.SetParent(treeArea.transform);
            Vector3 localPos = new Vector3(x, y, 0);
            Vector3 worldPos = transform.TransformPoint(localPos);
            gemClone.GetComponent<RectTransform>().localPosition = localPos;
            gemClone.SetActive(true);

            if (StaticVariables.Level == 5)
                cam.GetComponent<Frozen>().AddFrozenGem(gemClone, treeArea, canvas, new Vector2(x, y));

            StartCoroutine(FadeAlpha(gemClone, 1.5f));

            ruleObjects.Add(gemClone);

            cam.GetComponent<AnimateDigging>().DrawLine(prevNode, gemClone);

            startWidth += splitWidth;
        }

        treeArea.transform.SetParent(this.GetComponent<ScaleViewport>().contentScaler.transform);

         
        List<GameObject> endWord = cam.GetComponent<EndWord>().UpdateEndWord(ruleObjects, prevNode);
        tree.Add(ruleObjects);
        DataToCSV.EndWordUpdateLine(StaticVariables.Level.ToString(), cam.GetComponent<EndWord>().GetCurrentEndWordNames());

        if (cam.GetComponent<EndWord>().IsTreeDead())
        {
            isLevelEnd = true;
            this.gameObject.GetComponent<LevelMenuPanel>().DisableAllPopUps();
            bool isCorrect = cam.GetComponent<LevelSolutions>().IsAnswerCorrect(endWord);
            StartCoroutine(cam.GetComponent<EndWord>().AnimateEndWord());

            StartCoroutine(LevelCompletePopUp(isCorrect));
            Debug.Log(isCorrect);
        } 
    }
    IEnumerator FadeAlpha(GameObject gem, float duration) 
    {
        var image = gem.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0f;
        var start = tempColor;
        tempColor.a = 1f;
        var end = tempColor;

        for (float t = 0f; t<duration; t+=Time.deltaTime) 
        {
            float normalizedTime = t/duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            gem.GetComponent<Image>().color = Color.Lerp(start, end, normalizedTime);
            yield return null;
        }
        gem.GetComponent<Image>().color = end; //without this, the value will end at something like 0.9992367
    }

    private IEnumerator LevelCompletePopUp(bool success)
    {
        timeElapsed = Time.time - timeElapsed;
        Debug.Log("Time taken = " + timeElapsed);
        float secs = (cam.GetComponent<EndWord>().GetEndWordLength() * 0.5f) + 2.5f;

        yield return new WaitForSeconds(secs);
        
        if (success)
        {
            BadgeUnlock badgeComponent = this.GetComponent<BadgeUnlock>();
            if (badgeComponent)
                cam.GetComponent<SceneLoad>().isBadge = cam.GetComponent<BadgeUnlock>().BadgeToBeShown();
            int noOfStars = cam.GetComponent<LevelSolutions>().GetNumberOfStars(timeElapsed, numberOfNodesUsed);
            cam.GetComponent<LevelEnd>().LevelSuccess(noOfStars);
            DataToCSV.EndOfLevelLine(StaticVariables.Level.ToString(), "Success", numberOfNodesUsed.ToString(), timeElapsed.ToString(), noOfStars.ToString());
        }
        else
        {
            LoseLife();
            SetLevelFails(noOfFails += 1);
            cam.GetComponent<EndWord>().LevelFailRemoveCoins();
            cam.GetComponent<LevelEnd>().LevelFailed();
            DataToCSV.EndOfLevelLine(StaticVariables.Level.ToString(), "Failed", numberOfNodesUsed.ToString(), timeElapsed.ToString(), 0.ToString());
        }

        SaveProgress();
    }

    void CloneRuleContent(GameObject prevNode, GameObject image, float width, float height)
    {
        GameObject gemClone = Instantiate(image, canvas.transform);
        gemClone.GetComponent<RectTransform>().anchoredPosition = new Vector2(width, height);
        gemClone.transform.SetParent(treeArea.transform);
        gemClone.SetActive(true);

        cam.GetComponent<AnimateDigging>().DrawLine(prevNode, gemClone);
    }


    float RemapRange(float x, float oldMin, float oldMax, float newMin, float newMax)
    {
        return (((x - oldMin) * (newMax - newMin)) / (oldMax - oldMin)) + newMin;
    }

    void LoseLife()
    {
        if (StaticVariables.NoOfLives > 0)
        {
            StaticVariables.NoOfLives -= 1;
            noOfLives.GetComponent<Text>().text = StaticVariables.NoOfLives.ToString();
        }
        else
        {
            Debug.Log("No more lives");
        }

    }

    public void AddLife()
    {
        StaticVariables.NoOfLives += 1;
        noOfLives.GetComponent<Text>().text = StaticVariables.NoOfLives.ToString();
    }

    void SaveProgress()
    {
        PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount);
        PlayerPrefs.SetInt("Lives", StaticVariables.NoOfLives);
        switch(StaticVariables.Level) 
        {
            case 1:
                if (PlayerPrefs.GetInt("Level1Stars") < StaticVariables.Level1Stars)
                    PlayerPrefs.SetInt("Level1Stars", StaticVariables.Level1Stars);
                break;
            case 2:
                if (PlayerPrefs.GetInt("Level2Stars") < StaticVariables.Level2Stars)
                    PlayerPrefs.SetInt("Level2Stars", StaticVariables.Level2Stars);
                break;
            case 3:
                if (PlayerPrefs.GetInt("Level3Stars") < StaticVariables.Level3Stars)
                    PlayerPrefs.SetInt("Level3Stars", StaticVariables.Level3Stars);
                break;
            case 4:
                if (PlayerPrefs.GetInt("Level4Stars") < StaticVariables.Level4Stars)
                    PlayerPrefs.SetInt("Level4Stars", StaticVariables.Level4Stars);
                break;
            case 5:
                if (PlayerPrefs.GetInt("Level5Stars") < StaticVariables.Level5Stars)
                    PlayerPrefs.SetInt("Level5Stars", StaticVariables.Level5Stars);
                break;
            case 6:
                if (PlayerPrefs.GetInt("Level6Stars") < StaticVariables.Level6Stars)
                    PlayerPrefs.SetInt("Level6Stars", StaticVariables.Level6Stars);
                break;
            case 7:
                if (PlayerPrefs.GetInt("Level7Stars") < StaticVariables.Level7Stars)
                    PlayerPrefs.SetInt("Level7Stars", StaticVariables.Level7Stars);
                break;
            case 8:
                if (PlayerPrefs.GetInt("Level8Stars") < StaticVariables.Level8Stars)
                    PlayerPrefs.SetInt("Level8Stars", StaticVariables.Level8Stars);
                break;
            case 9:
                if (PlayerPrefs.GetInt("Level9Stars") < StaticVariables.Level9Stars)
                    PlayerPrefs.SetInt("Level9Stars", StaticVariables.Level9Stars);
                break;
            case 10:
                if (PlayerPrefs.GetInt("Level10Stars") < StaticVariables.Level10Stars)
                    PlayerPrefs.SetInt("Level10Stars", StaticVariables.Level10Stars);
                break;
        }
        
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    int GetLevelFails()
    {
        switch(StaticVariables.Level) 
        {
            case 1:
                return StaticVariables.Level1Fails;
            case 2:
                return StaticVariables.Level2Fails;
            case 3:
                return StaticVariables.Level3Fails;
            case 4:
                return StaticVariables.Level4Fails;
            case 5:
                return StaticVariables.Level5Fails;
            case 6:
                return StaticVariables.Level6Fails;
            case 7:
                return StaticVariables.Level7Fails;
            case 8:
                return StaticVariables.Level8Fails;
            case 9:
                return StaticVariables.Level9Fails;
            case 10:
                return StaticVariables.Level10Fails;
        }
        return 0;
    }
    void SetLevelFails(int noOfFails)
    {
        switch(StaticVariables.Level) 
        {
            case 1:
                StaticVariables.Level1Fails = noOfFails;
                break;
            case 2:
                StaticVariables.Level2Fails = noOfFails;
                break;
            case 3:
                StaticVariables.Level3Fails = noOfFails;
                break;
            case 4:
                StaticVariables.Level4Fails = noOfFails;
                break;
            case 5:
                StaticVariables.Level5Fails = noOfFails;
                break;
            case 6:
                StaticVariables.Level6Fails = noOfFails;
                break;
            case 7:
                StaticVariables.Level7Fails = noOfFails;
                break;
            case 8:
                StaticVariables.Level8Fails = noOfFails;
                break;
            case 9:
                StaticVariables.Level9Fails = noOfFails;
                break;
            case 10:
                StaticVariables.Level10Fails = noOfFails;
                break;
        }
    }
    
}



