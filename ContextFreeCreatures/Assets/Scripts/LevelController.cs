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

    public Canvas canvas;

    private GameObject treeArea;
    private GameObject treeOutline;
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
    float maxHeight;

    private void Start() 
    {
        DataToCSV.AddNewLevelLine(StaticVariables.CurrentLevel.ToString());
        treeArea = GameObject.Find("TreeSpace");
        treeOutline = GameObject.Find("TreeOutline");
        cam = GameObject.Find("Main Camera");
        rectTransform = (RectTransform)treeArea.transform;
        treeSpaceWidth = rectTransform.rect.width;
        treeSpaceHeight = rectTransform.rect.height;
        RectTransform outlineTransform = (RectTransform)treeOutline.transform;
        maxWidth = outlineTransform.rect.width;
        maxHeight = outlineTransform.rect.height;
        timeElapsed = Time.time;
        noOfLives.GetComponent<Text>().text = PlayerPrefs.GetInt("Lives").ToString();
        StaticVariables.NoOfLives = PlayerPrefs.GetInt("Lives");
        if (StaticVariables.CurrentLevel > 0)
        {
            cam.GetComponent<MusicControl>().SetSliderValue(StaticVariables.VolumeLevel);
            cam.GetComponent<MusicControl>().SetMusicSliderValue(StaticVariables.MusicVolumeLevel);
        }
        

        treeArea.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-29.0f);
    }
    public void SetCurrentTime(float time)
    {
        timeElapsed = time;
    }

    public void ReplaceNode(GameObject creatureImage, Vector3 node)
    {
        // this.GetComponent<ScaleViewport>().contentScaler.transform.DetachChildren();
        GameObject bkg = Instantiate(spriteBackground, canvas.transform);
        bkg.transform.SetParent(treeArea.transform);
        bkg.GetComponent<RectTransform>().transform.position = node;
        bkg.SetActive(true);

        GameObject creature = Instantiate(creatureImage, canvas.transform);
        creature.transform.SetParent(treeArea.transform);
        creature.GetComponent<RectTransform>().transform.position = node;
        creature.SetActive(true);

        numberOfNodesUsed += 1;
        // treeArea.transform.SetParent(this.GetComponent<ScaleViewport>().contentScaler.transform);

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

        bool prevNodeAlone = false;

        for (int i = 0; i < tree.Count; i++)
        {
            for (int j = 0; j < tree[i].Count; j++)
            {
                if (tree[i][j] == prevNode)
                    if (tree[i].Count == 1)
                        prevNodeAlone = true;
            }
        }

        if (prevNode == startNode || (tree.Count == 1 && prevNodeAlone))
        {
            startWidth = -treeSpaceWidth/(imageCount*2);
            splitWidth = (treeSpaceWidth + (treeSpaceWidth/imageCount))/(imageCount + 1);
            startWidth += splitWidth;
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
                            if (tree[i].Count == 1)
                            {
                                nodeNeighX = 300f;
                                break;
                            }
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
                float newWidth = Mathf.Abs(nodeNeighX - nodeX) - 100;

                if (ruleImages.Count > 2)
                    splitWidth = (newWidth/(imageCount-1));
                else
                    splitWidth = newWidth;
                startWidth = nodeX - (newWidth/2);

                Debug.Log (newWidth);
                if (newWidth <= imageCount*20f)
                {
                    Debug.Log("Level should fail");
                    isLevelEnd = true;
                    StartCoroutine(LevelCompletePopUp(false));
                }

                if (startWidth < 0 || (startWidth + newWidth) >= maxWidth)
                {
                    this.GetComponent<ScaleViewport>().ScaleTreeSizeWidth(maxWidth + (Mathf.Abs(startWidth)*2) + 100f, treeSpaceHeight, 0);
                    maxWidth = maxWidth + (Mathf.Abs(startWidth)*2) + 100f;
                }

            }

            if (height <= 5 )
            {             
                this.GetComponent<ScaleViewport>().ScaleTreeSizeHeight(maxHeight, maxHeight + 170f);
                Debug.Log(height);
                maxHeight = maxHeight + 170f;
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

            if (StaticVariables.CurrentLevel == 5)
                cam.GetComponent<Frozen>().AddFrozenGem(gemClone, treeArea, canvas, gemClone.GetComponent<RectTransform>().transform.position);

            StartCoroutine(FadeAlpha(gemClone, 1.5f));

            ruleObjects.Add(gemClone);

            cam.GetComponent<AnimateDigging>().DrawLine(prevNode, gemClone);

            startWidth += splitWidth;
        }

        treeArea.transform.SetParent(this.GetComponent<ScaleViewport>().contentScaler.transform);
        treeArea.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
         
        List<GameObject> endWord = cam.GetComponent<EndWord>().UpdateEndWord(ruleObjects, prevNode);
        tree.Add(ruleObjects);
        DataToCSV.EndWordUpdateLine(StaticVariables.CurrentLevel.ToString(), cam.GetComponent<EndWord>().GetCurrentEndWordNames());

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
            DataToCSV.EndOfLevelLine(StaticVariables.CurrentLevel.ToString(), "Success", numberOfNodesUsed.ToString(), timeElapsed.ToString(), noOfStars.ToString());
        }
        else
        {
            LoseLife();
            cam.GetComponent<EndWord>().LevelFailRemoveCoins();
            cam.GetComponent<LevelEnd>().LevelFailed();
            DataToCSV.EndOfLevelLine(StaticVariables.CurrentLevel.ToString(), "Failed", numberOfNodesUsed.ToString(), timeElapsed.ToString(), 0.ToString());
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
        if (StaticVariables.NoOfLives > 1)
        {
            if (StaticVariables.CurrentLevel > StaticVariables.MaxReachedLevel)
            {
                StaticVariables.NoOfLives -= 1;
                noOfLives.GetComponent<Text>().text = StaticVariables.NoOfLives.ToString();
            }
        }
        else
        {
            this.GetComponent<SceneLoad>().ToLevelSelector();
            StaticVariables.NoOfLives = 0;
            PlayerPrefs.SetInt("Lives", StaticVariables.NoOfLives);
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
        if (StaticVariables.CurrentLevel >= StaticVariables.MaxReachedLevel)
        {
            StaticVariables.MaxReachedLevel = StaticVariables.CurrentLevel;
            PlayerPrefs.SetInt("MaxReachedLevel", StaticVariables.MaxReachedLevel);
        }
        switch (StaticVariables.CurrentLevel) 
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
            case 11:
                if (PlayerPrefs.GetInt("Level11Stars") < StaticVariables.Level11Stars)
                    PlayerPrefs.SetInt("Level11Stars", StaticVariables.Level11Stars);
                break;
            case 12:
                if (PlayerPrefs.GetInt("Level12Stars") < StaticVariables.Level12Stars)
                    PlayerPrefs.SetInt("Level12Stars", StaticVariables.Level12Stars);
                break;
            case 13:
                if (PlayerPrefs.GetInt("Level13Stars") < StaticVariables.Level13Stars)
                    PlayerPrefs.SetInt("Level13Stars", StaticVariables.Level13Stars);
                break;
            case 14:
                if (PlayerPrefs.GetInt("Level14Stars") < StaticVariables.Level14Stars)
                    PlayerPrefs.SetInt("Level14Stars", StaticVariables.Level14Stars);
                break;
            case 15:
                if (PlayerPrefs.GetInt("Level15Stars") < StaticVariables.Level15Stars)
                    PlayerPrefs.SetInt("Level15Stars", StaticVariables.Level15Stars);
                break;
        }
        
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
    
}



