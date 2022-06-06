using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeStructure : MonoBehaviour
{
    private float maxRows = 5;
    private List<GameObject> row1 = new List<GameObject>();
    private List<GameObject> row2 = new List<GameObject>();
    private List<GameObject> row3 = new List<GameObject>();
    private List<GameObject> row4 = new List<GameObject>();
    private List<GameObject> row5 = new List<GameObject>();


    private List<GameObject> endWord = new List<GameObject>();
    private int headOfEndWord = 0;

    private List<List<GameObject>> allRows = new List<List<GameObject>>();

    private GameObject startNode;
    private GameObject treeArea;
    private RectTransform rectTransform;
    float treeSpaceWidth;
    float treeSpaceHeight;


    // Start is called before the first frame update
    void Start()
    {
        treeArea = GameObject.Find("TreeSpace");
        startNode = GameObject.Find("StartNode");
        rectTransform = (RectTransform)treeArea.transform;
        treeSpaceWidth = rectTransform.rect.width;
        treeSpaceHeight = rectTransform.rect.height;
        row1.Add(startNode);
        endWord.Add(startNode);
        allRows.Add(row1);
        allRows.Add(row2);
        allRows.Add(row3);
        allRows.Add(row4);
        allRows.Add(row5);
    }

    public int GetNextEmptyRow()
    {
        for (int i = 0; i < allRows.Count; i ++)
        {
            if (allRows[i].Count == 0)
                return i;
        }
        return 0;
    }
    
    public void AddElementToList(int index, GameObject element)
    {
        allRows[index].Add(element);
        UpdateEndWord(element);
    }

    void UpdateEndWord(GameObject element)
    {
        for (int i = 0; i < endWord.Count; i++)
        {
            if (endWord[i].gameObject.name.Contains("Node"))
            {
                endWord[i] = element;
                headOfEndWord = i;
            }
            else
            {
                endWord.Insert(headOfEndWord, element);
                headOfEndWord += 1;
            }
        }
        
        
    }

    public bool IsTreeDead(int index)
    {        
        for (int i = 0; i < allRows[index].Count; i ++)
        {
            if (allRows[index][i].gameObject.name.Contains("Node"))
            {
                return false;
            }
        }

        return true;
    }
}
