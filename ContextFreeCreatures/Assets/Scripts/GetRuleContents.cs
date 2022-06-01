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
        float splitWidth = treeSpaceWidth/ruleImages.Count;
        float splitHeight = treeSpaceWidth/2;


        float width = -splitWidth/2;

        for (int i = 0; i < ruleImages.Count; i++)
        {
            
            GameObject gemClone = Instantiate(ruleImages[i], canvas.transform);

            gemClone.GetComponent<RectTransform>().anchoredPosition = new Vector2(width/2, 0);

            width = splitHeight/2;
            // height += 20;
            
            gemClone.SetActive(true);
        }

        // for (int i = 0; i < this.gameObject.transform.childCount; i++)
        // {
        //     GameObject child = this.gameObject.transform.GetChild(i).gameObject;
        //     switch (child.name)
        //     {
        //         case "Green":
        //             Debug.Log("Contains Green");
        //             break;
        //         case "Blue":
        //             Debug.Log("Contains Blue");
        //             break;
        //         case "Purple":
        //             Debug.Log("Contains Purple");
        //             break;
        //         case "Red":
        //             Debug.Log("Contains Red");
        //             break;
        //         case "Yellow":
        //             Debug.Log("Contains Yellow");
        //             break;
        //         case "Pink":
        //             Debug.Log("Contains Pink");
        //             break;   
        //         case "Node":
        //             Debug.Log("Contains Node");
        //             break;    
        //         default:
        //             break;                                                      
        //     }
        // }
    }
}
