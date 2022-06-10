using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndWord : MonoBehaviour
{

    GameObject startNode;

    private List<GameObject> endWord = new List<GameObject>();

    private void Start() 
    {
        startNode = GameObject.Find("StartNode");
        endWord.Add(startNode);
    }


    public List<GameObject> UpdateEndWord(List<GameObject> elements)
    {
        int index = -1;
        for (int i = 0; i < endWord.Count; i ++)
        {
            if (endWord[i].gameObject.name.Contains("Node"))
            {
                index = i;
                endWord.RemoveAt(i);
            }
        }
        endWord.InsertRange(index, elements);
        return endWord;
    }

    public bool IsTreeDead()
    {        
        for (int i = 0; i < endWord.Count; i ++)
        {
            if (endWord[i].gameObject.name.Contains("Node"))
            {
                return false;
            }
        }

        return true;
    }

    public void AnimateEndWord()
    {
        for (int i = 0; i < endWord.Count; i++)
        {
            if (endWord[i].gameObject.name.Contains("Green"))
            {
                endWord[i].GetComponent<Animator>().enabled = true;
                endWord[i].GetComponent<Animator>().Play("Green Gem Pop");
            }
        }
    }    
    
}
