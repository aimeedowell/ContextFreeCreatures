using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelController : MonoBehaviour
{
    GameObject cam;
    public List<GameObject> ruleImages;
    public GameObject creatureImage;
    public GameObject startNode;
    public Canvas canvas;

    private List<float> heights = new List<float>();

    private List<float> posWidths = new List<float>();

    private GameObject treeArea;
    private RectTransform rectTransform;

    float treeSpaceWidth;
    float treeSpaceHeight;
    private float maxRows = 6;

    private Vector2 nodeAnchPos;

    private void Start() 
    {
        treeArea = GameObject.Find("TreeSpace");
        cam = GameObject.Find("Main Camera");
        rectTransform = (RectTransform)treeArea.transform;
        treeSpaceWidth = rectTransform.rect.width;
        treeSpaceHeight = rectTransform.rect.height;      
    }

    public void ReplaceNode(Vector2 node)
    {
        GameObject creature = Instantiate(creatureImage, canvas.transform);
        creature.GetComponent<RectTransform>().anchoredPosition = node;
        nodeAnchPos = node;
        creature.transform.SetParent(treeArea.transform);
        creature.SetActive(true);
    }

    public void GetContents(float prevNodeY)
    {
        int imageCount = ruleImages.Count;

        float splitHeight = treeSpaceHeight/maxRows;
        float startHeight = prevNodeY;
        startHeight = RemapRange(startHeight, -treeSpaceHeight/2, treeSpaceHeight/2,  0, treeSpaceHeight);
        Debug.Log(startHeight);
  
        float splitWidth = treeSpaceWidth/(imageCount + 1); //want to measure no of spaces
        float startWidth = 0f;
        
        float height = startHeight - splitHeight;

        List<GameObject> ruleObjects = new List<GameObject>();

        for (int i = 0; i < ruleImages.Count; i++)
        {
            ruleObjects.Add(ruleImages[i]);

            float width = (startWidth + splitWidth);

            Debug.Log("Height img" + i + " is " + height  + "Width img" + i + " is  " + width);

            float x = RemapRange(width, 0, treeSpaceWidth, -treeSpaceWidth/2, treeSpaceWidth/2);

            float y = RemapRange(height, 0, treeSpaceHeight, -treeSpaceHeight/2, treeSpaceHeight/2);

            // if (y > 0)
            //     y = -y;
            // else
            //     y = Math.Abs(y);

            CloneRuleContent(ruleImages[i], x, y);

            startWidth += splitWidth;
            
        }

        List<GameObject> endWord = cam.GetComponent<EndWord>().UpdateEndWord(ruleObjects);

        bool isCorrect = false;
        if (cam.GetComponent<EndWord>().IsTreeDead())
        {
            isCorrect = cam.GetComponent<LevelSolutions>().IsAnswerCorrect(endWord);
        }
        if (isCorrect)
        {
            cam.GetComponent<LevelEnd>().LevelSuccess(3);
        }
        Debug.Log(isCorrect);
    }

    void CloneRuleContent(GameObject image, float width, float height)
    {
        GameObject gemClone = Instantiate(image, canvas.transform);
        gemClone.GetComponent<RectTransform>().anchoredPosition = new Vector2(width, height);
        gemClone.transform.SetParent(treeArea.transform);
        gemClone.SetActive(true);
    }


    float RemapRange(float x, float oldMin, float oldMax, float newMin, float newMax)
    {
        return (((x - oldMin) * (newMax - newMin)) / (oldMax - oldMin)) + newMin;
    }
    
}


