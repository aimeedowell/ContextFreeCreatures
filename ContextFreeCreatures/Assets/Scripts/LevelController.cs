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

    private List<float> posWidths = new List<float>();

    private GameObject treeArea;
    private RectTransform rectTransform;

    float treeSpaceWidth;
    float treeSpaceHeight;
    private float maxRows = 6;

    private List<List<GameObject>> tree = new List<List<GameObject>>();
    private Vector2 nodeAnchPos;

    private float timeElapsed = 0f;
    private int numberOfNodesUsed = 0;

    public bool isLevelEnd = false;

    public Text noOfLives;


    private void Start() 
    {
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
    }

    public void ReplaceNode(GameObject creatureImage, Vector2 node)
    {
        GameObject bkg = Instantiate(spriteBackground, canvas.transform);
        bkg.GetComponent<RectTransform>().anchoredPosition = node;
        nodeAnchPos = node;
        bkg.transform.SetParent(treeArea.transform);
        bkg.SetActive(true);

        GameObject creature = Instantiate(creatureImage, canvas.transform);
        creature.GetComponent<RectTransform>().anchoredPosition = node;
        nodeAnchPos = node;
        creature.transform.SetParent(treeArea.transform);
        creature.SetActive(true);

        numberOfNodesUsed += 1;
    }

    public void GetContents(List<GameObject> ruleImages, GameObject prevNode, float prevNodeY)
    {
        int imageCount = ruleImages.Count;
        List<GameObject> ruleObjects = new List<GameObject>();

        float splitHeight = treeSpaceHeight/maxRows;
        float startHeight = prevNodeY;
        startHeight = RemapRange(startHeight, -treeSpaceHeight/2, treeSpaceHeight/2,  0, treeSpaceHeight);
        float height = startHeight - splitHeight;

        float splitWidth = 0;
        float startWidth = 0f;

        if (prevNode == startNode)
        {
            startWidth = -treeSpaceWidth/(imageCount*2);
            splitWidth = (treeSpaceWidth + (treeSpaceWidth/imageCount))/(imageCount + 1);
            startWidth += splitWidth;
        }
        else
        {
            if (ruleImages.Count == 1)
                startWidth = RemapRange(prevNode.transform.localPosition.x, -treeSpaceWidth/2, treeSpaceWidth/2, 0, treeSpaceWidth);
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


                float nodeX = RemapRange(prevNode.transform.localPosition.x, -treeSpaceWidth/2, treeSpaceWidth/2, 0, treeSpaceWidth);
                float newWidth = Mathf.Abs(nodeNeighX - nodeX) - 100f;

                if (ruleImages.Count > 2)
                    splitWidth = (newWidth/(imageCount-1));
                else
                    splitWidth = newWidth;
                startWidth = Mathf.Abs(nodeX - (newWidth/2));

            }
        }

        for (int i = 0; i < ruleImages.Count; i++)
        {
            float x = RemapRange(startWidth, 0, treeSpaceWidth, -treeSpaceWidth/2, treeSpaceWidth/2);

            float y = RemapRange(height, 0, treeSpaceHeight, -treeSpaceHeight/2, treeSpaceHeight/2);
            
            GameObject gemClone = Instantiate(ruleImages[i], canvas.transform);
            gemClone.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            gemClone.transform.SetParent(treeArea.transform);
            gemClone.SetActive(true);

            if (StaticVariables.Level == 5)
                cam.GetComponent<Frozen>().AddFrozenGem(gemClone, treeArea, canvas, new Vector2(x, y));

            StartCoroutine(FadeAlpha(gemClone, 1.5f));

            ruleObjects.Add(gemClone);

            cam.GetComponent<AnimateDigging>().DrawLine(prevNode, gemClone);

            startWidth += splitWidth;
        }

         
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
            cam.GetComponent<SceneLoad>().isBadge = true;
            int noOfStars = cam.GetComponent<LevelSolutions>().GetNumberOfStars(timeElapsed, numberOfNodesUsed);
            cam.GetComponent<LevelEnd>().LevelSuccess(noOfStars);
            DataToCSV.EndOfLevelLine(StaticVariables.Level.ToString(), "Success", numberOfNodesUsed.ToString(), timeElapsed.ToString());
        }
        else
        {
            LoseLife();
            cam.GetComponent<EndWord>().LevelFailRemoveCoins();
            cam.GetComponent<LevelEnd>().LevelFailed();
            DataToCSV.EndOfLevelLine(StaticVariables.Level.ToString(), "Failed", numberOfNodesUsed.ToString(), timeElapsed.ToString());
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
                PlayerPrefs.SetInt("Level1Stars", StaticVariables.Level1Stars);
                break;
            case 2:
                PlayerPrefs.SetInt("Level2Stars", StaticVariables.Level2Stars);
                break;
            case 3:
                PlayerPrefs.SetInt("Level3Stars", StaticVariables.Level3Stars);
                break;
            case 4:
                PlayerPrefs.SetInt("Level4Stars", StaticVariables.Level4Stars);
                break;
            case 5:
                PlayerPrefs.SetInt("Level5Stars", StaticVariables.Level5Stars);
                break;
            case 6:
                PlayerPrefs.SetInt("Level6Stars", StaticVariables.Level6Stars);
                break;
            case 7:
                PlayerPrefs.SetInt("Level7Stars", StaticVariables.Level7Stars);
                break;
            case 8:
                PlayerPrefs.SetInt("Level8Stars", StaticVariables.Level8Stars);
                break;
            case 9:
                PlayerPrefs.SetInt("Level9Stars", StaticVariables.Level9Stars);
                break;
            case 10:
                PlayerPrefs.SetInt("Level10Stars", StaticVariables.Level10Stars);
                break;
        }
        
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
    
}



