using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndWord : MonoBehaviour
{

    public Canvas canvas;
    GameObject startNode;

    public Text coinScore;

    public GameObject coinAnimation;

    GameObject coinContainer;

    private List<GameObject> endWord = new List<GameObject>();

    public List<GameObject> targetWord;

    private void Start() 
    {
        startNode = GameObject.Find("StartNode");
        coinContainer = GameObject.Find("CoinContainer");
        endWord.Add(startNode);
        coinScore.GetComponent<Text>().text = StaticVariables.CoinCount.ToString();
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
                    endWord[i].GetComponent<AudioSource>().Play(0);
                    targetWord[i].GetComponent<Animator>().Play("TGreenPop");
                    CollectDiamondPrize();
                    DuplicateCoin(endWord[i].GetComponent<RectTransform>().anchoredPosition);
                }
                else if (endWord[i].gameObject.name.Contains("Blue") && targetWord[i].gameObject.name.Contains("Blue"))
                {
                    endWord[i].GetComponent<Animator>().enabled = true;
                    targetWord[i].GetComponent<Animator>().enabled = true;
                    endWord[i].GetComponent<Animator>().Play("BlueGemPop");
                    endWord[i].GetComponent<AudioSource>().Play(0);
                    targetWord[i].GetComponent<Animator>().Play("TBluePop");
                    CollectDiamondPrize();
                    DuplicateCoin(endWord[i].GetComponent<RectTransform>().anchoredPosition);
                    
                }
                else if (endWord[i].gameObject.name.Contains("Purple") && targetWord[i].gameObject.name.Contains("Purple"))
                {
                    endWord[i].GetComponent<Animator>().enabled = true;
                    targetWord[i].GetComponent<Animator>().enabled = true;
                    endWord[i].GetComponent<Animator>().Play("PurpleGemPop");
                    endWord[i].GetComponent<AudioSource>().Play(0);
                    targetWord[i].GetComponent<Animator>().Play("TPurplePop");
                    CollectDiamondPrize();
                    DuplicateCoin(endWord[i].GetComponent<RectTransform>().anchoredPosition);
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

    void CollectDiamondPrize()
    {
        StaticVariables.CoinCount += StaticVariables.DiamondPrize;
        coinScore.GetComponent<Text>().text = StaticVariables.CoinCount.ToString();

    }

    void DuplicateCoin(Vector2 gemPos)
    {
        GameObject coinClone = Instantiate(coinAnimation, canvas.transform);
        coinClone.GetComponent<RectTransform>().anchoredPosition = gemPos;
        coinClone.transform.SetParent(coinContainer.transform);
        coinClone.SetActive(true); 
        
        coinClone.GetComponent<Animator>().enabled = true;
        coinClone.GetComponent<Animator>().Play("CoinSpin");
        coinClone.GetComponent<AudioSource>().Play(0);
    }
    
}
