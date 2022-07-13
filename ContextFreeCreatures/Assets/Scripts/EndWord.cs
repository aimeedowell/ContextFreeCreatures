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

    int startCoinScore;

    private void Start() 
    {
        startNode = GameObject.Find("StartNode");
        coinContainer = GameObject.Find("CoinContainer");
        endWord.Add(startNode);
        coinScore.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
        startCoinScore = PlayerPrefs.GetInt("Coins");
        StaticVariables.CoinCount = PlayerPrefs.GetInt("Coins");
    }


    public List<GameObject> UpdateEndWord(List<GameObject> elements, GameObject prevNode)
    {
        int index = -1;
        for (int i = 0; i < endWord.Count; i ++)
        {
            if (endWord[i] == prevNode)
            {
                index = i;
                endWord.RemoveAt(i);
            }
        }
        if (!elements[0].gameObject.name.Contains("Dirt"))
            endWord.InsertRange(index, elements);
        return endWord;
    }

    public List<string> GetCurrentEndWordNames()
    {
        List<string> newList = new List<string>();
        for (int i = 0; i < endWord.Count; i ++)
        {
            newList.Add(endWord[i].gameObject.name);
        }
        return newList;
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
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < endWord.Count; i++)
        {
            if (i < targetWord.Count)
            {
                if (endWord[i].gameObject.name.Contains("Green") && targetWord[i].gameObject.name.Contains("Green"))
                    DiamondPop(endWord[i], targetWord[i]);
                else if (endWord[i].gameObject.name.Contains("DarkBlue") && targetWord[i].gameObject.name.Contains("DarkBlue"))
                    DiamondPop(endWord[i], targetWord[i]);                   
                else if (endWord[i].gameObject.name.Contains("Yellow") && targetWord[i].gameObject.name.Contains("Yellow"))
                    DiamondPop(endWord[i], targetWord[i]);  
                else if (endWord[i].gameObject.name.Contains("Red") && targetWord[i].gameObject.name.Contains("Red"))
                    DiamondPop(endWord[i], targetWord[i]);
                else if (endWord[i].gameObject.name.Contains("Blue") && targetWord[i].gameObject.name.Contains("Blue"))
                    DiamondPop(endWord[i], targetWord[i]);
                else if (endWord[i].gameObject.name.Contains("Purple") && targetWord[i].gameObject.name.Contains("Purple"))
                    DiamondPop(endWord[i], targetWord[i]);
                else if (endWord[i].gameObject.name.Contains("Pink") && targetWord[i].gameObject.name.Contains("Pink"))
                    DiamondPop(endWord[i], targetWord[i]);
                else if (endWord[i].gameObject.name.Contains("Orange") && targetWord[i].gameObject.name.Contains("Orange"))
                    DiamondPop(endWord[i], targetWord[i]);
                else
                    yield break;
                yield return new WaitForSeconds(0.5f);
            }
            else
                yield break;
        }
    }    

    void DiamondPop(GameObject endWord, GameObject targetWord)
    {
        targetWord.GetComponent<Animator>().enabled = true;
        targetWord.GetComponent<Animator>().Play(0);

        if (StaticVariables.Level == 5 && this.gameObject.GetComponent<Frozen>().IsGemFrozen(endWord))
        {
            Debug.Log("Gem is Frozen");
            this.gameObject.GetComponent<Frozen>().PlayFreezeAnimation(endWord);
        }
        else
        {
            endWord.GetComponent<Animator>().enabled = true;
            endWord.GetComponent<Animator>().Play(0);
            endWord.GetComponent<AudioSource>().Play(0);
            CollectDiamondPrize();
            DuplicateCoin(endWord.GetComponent<RectTransform>().transform.position);
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
        coinClone.transform.SetParent(coinContainer.transform);
        coinClone.GetComponent<RectTransform>().transform.position = gemPos;
        coinClone.SetActive(true); 
        
        coinClone.GetComponent<Animator>().enabled = true;
        coinClone.GetComponent<Animator>().Play("CoinSpin");
        coinClone.GetComponent<AudioSource>().Play(0);
    }

    public void LevelFailRemoveCoins()
    {
        int loss = StaticVariables.CoinCount - startCoinScore;
        int newScore = StaticVariables.CoinCount - loss;
        coinScore.GetComponent<Text>().text = newScore.ToString();
    }
    
}
