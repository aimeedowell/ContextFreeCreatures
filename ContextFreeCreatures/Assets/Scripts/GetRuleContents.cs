using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetRuleContents : MonoBehaviour
{
    GameObject cam;
    public List<GameObject> ruleImages;
    public GameObject creatureImage;
    public GameObject startNode;
    public Canvas canvas;

    private List<float> heights = new List<float>();
    private GameObject treeArea;
    private RectTransform rectTransform;

    float treeSpaceWidth;
    float treeSpaceHeight;
    private float maxRows = 5;

    private void Start() 
    {
        treeArea = GameObject.Find("TreeSpace");
        cam = GameObject.Find("Main Camera");
        rectTransform = (RectTransform)treeArea.transform;
        treeSpaceWidth = rectTransform.rect.width;
        treeSpaceHeight = rectTransform.rect.height;
        SetHeights();        
    }

    public void ReplaceNode(Vector2 node)
    {
        GameObject creature = Instantiate(creatureImage, canvas.transform);
        creature.GetComponent<RectTransform>().anchoredPosition = node;
        creature.transform.SetParent(treeArea.transform);
        creature.SetActive(true);
    }

    void SetHeights()
    {
        float mid = maxRows/2;
        float halfHeight = treeSpaceHeight/2;
        float splitHalfHeight = halfHeight/(maxRows-1);
        float startingHeightPos = startNode.transform.localPosition.y;
        Debug.Log(startingHeightPos);

        for (int i = 0; i < maxRows; i++)
        {
            if (i == Math.Round(mid) + 1)
            {
                startingHeightPos = 0;
            }
            
            if (i == Math.Round(mid))
            {
                startingHeightPos = 0;
            }
            else
            {
                startingHeightPos -= splitHalfHeight;
            }
            heights.Add(startingHeightPos);
            // Debug.Log(heights[i]);
        }
        
    }

    int GetNextHeightIndex(float nodePos)
    {
        for (int i = 0; i < heights.Count; i++)
        {
            if (nodePos == heights[i])
                return i + 1;
        }
        return 0;
    }

    public void GetContents(GameObject prev, float nodePos)
    {
        float halfWidth = treeSpaceWidth/2;

        float centrePos = 0f;
        int imageCount = ruleImages.Count;

        Debug.Log(nodePos);
        float startingWidthPos = -halfWidth;
        int heightIdx = cam.GetComponent<TreeStructure>().GetNextEmptyRow();
  
        float height = heights[heightIdx];

        for (int i = 0; i < ruleImages.Count; i++)
        {
            if (imageCount % 2 == 0)
            {
                float splitHalfWidth = halfWidth/imageCount;
                
                float halfImages = imageCount/2;

                if (i == halfImages)
                {
                    startingWidthPos = centrePos;
                }
                startingWidthPos += splitHalfWidth;
            
                CloneRuleContent(ruleImages[i], startingWidthPos, height, heightIdx);
            }
            else
            {
                float splitHalfWidth = halfWidth/(imageCount-1);
                float halfImages = imageCount/2;

                if (i > halfImages)
                {
                    startingWidthPos = 0;
                }
                
                if (i == Math.Round(halfImages))
                {
                    startingWidthPos = 0;
                }
                else
                {
                    startingWidthPos += splitHalfWidth;
                }

                CloneRuleContent(ruleImages[i], startingWidthPos, height, heightIdx);
            }
        }

        bool isLevelOver = cam.GetComponent<TreeStructure>().IsTreeDead(heightIdx);
        Debug.Log(isLevelOver);
    }

    void CloneRuleContent(GameObject image, float width, float height, int listIndex)
    {
        GameObject gemClone = Instantiate(image, canvas.transform);
        gemClone.GetComponent<RectTransform>().anchoredPosition = new Vector2(width, height);
        gemClone.transform.SetParent(treeArea.transform);
        gemClone.SetActive(true);
        cam.GetComponent<TreeStructure>().AddElementToList(listIndex, gemClone);
    }
}


