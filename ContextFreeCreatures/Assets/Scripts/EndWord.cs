using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndWord : MonoBehaviour
{

    GameObject startNode;

    private List<GameObject> endWord = new List<GameObject>();

    public List<GameObject> targetWord;

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

    public IEnumerator AnimateEndWord()
    {
        for (int i = 0; i < endWord.Count; i++)
        {
            if (i < targetWord.Count)
            {
                if (endWord[i].gameObject.name.Contains("Green") && targetWord[i].gameObject.name.Contains("Green"))
                {
                    endWord[i].GetComponent<Animator>().enabled = true;
                    targetWord[i].GetComponent<Animator>().enabled = true;
                    endWord[i].GetComponent<Animator>().Play("GreenGemPop");
                    targetWord[i].GetComponent<Animator>().Play("TGreenPop");
                }
                else if (endWord[i].gameObject.name.Contains("Blue") && targetWord[i].gameObject.name.Contains("Blue"))
                {
                    endWord[i].GetComponent<Animator>().enabled = true;
                    targetWord[i].GetComponent<Animator>().enabled = true;
                    endWord[i].GetComponent<Animator>().Play("BlueGemPop");
                    targetWord[i].GetComponent<Animator>().Play("TBluePop");
                }
                else if (endWord[i].gameObject.name.Contains("Purple") && targetWord[i].gameObject.name.Contains("Purple"))
                {
                    endWord[i].GetComponent<Animator>().enabled = true;
                    targetWord[i].GetComponent<Animator>().enabled = true;
                    endWord[i].GetComponent<Animator>().Play("PurpleGemPop");
                    targetWord[i].GetComponent<Animator>().Play("TPurplePop");
                }
                else
                    yield break;
                yield return new WaitForSeconds(0.5f);
            }
            else
                yield break;
        }
    }    

    public int GetEndWordLength()
    {
        return endWord.Count;
    }
    
}
