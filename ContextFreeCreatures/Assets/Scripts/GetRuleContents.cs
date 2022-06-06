using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRuleContents : MonoBehaviour
{
    public List<GameObject> ruleImages;
    public GameObject creatureImage;
    public Canvas canvas;

    private GameObject treeArea;
    private RectTransform rectTransform;

    float treeSpaceWidth;
    float treeSpaceHeight;

    private void Start() 
    {
        treeArea = GameObject.Find("TreeSpace");
        rectTransform = (RectTransform)treeArea.transform;
        treeSpaceWidth = rectTransform.rect.width;
        treeSpaceHeight = rectTransform.rect.height;
    }

    public void ReplaceNode(Vector2 node )
    {
        GameObject creature = Instantiate(creatureImage, canvas.transform);
        creature.GetComponent<RectTransform>().anchoredPosition = node;
        creature.SetActive(true);
    }

    public void GetContents()
    {
        float halfWidth = treeSpaceWidth/2;
        float splitHeight = treeSpaceHeight/2;

        float centrePos = 0f;
        int imageCount = ruleImages.Count;


        float startingWidthPos = -halfWidth;

        for (int i = 0; i < ruleImages.Count; i++)
        {
            if (imageCount % 2 == 0)
            {
                float splitHalfWidth = halfWidth/imageCount;
                float halfImages = imageCount/2;

                if (i == halfImages)
                {
                    startingWidthPos = 0;
                }

                startingWidthPos += splitHalfWidth;
            
                GameObject gemClone = Instantiate(ruleImages[i], canvas.transform);

                gemClone.GetComponent<RectTransform>().anchoredPosition = new Vector2(startingWidthPos, splitHeight);


                    // height += 20;
    
                
                gemClone.SetActive(true);
            }
        }
    }
}
