using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text coinScore;
    public GameObject shopMenu;
    public GameObject firstRule;
    public GameObject startNode;

    public GameObject coin100Button;
    public GameObject coin150Button;
    public GameObject coin500Button;

    public List<GameObject> listOfUnNeededRules = new List<GameObject>();

    void Update() 
    {
        if (shopMenu.activeSelf == true)
        {
            if (StaticVariables.CoinCount < 100)
            {
                coin100Button.GetComponent<Button>().interactable = false;
                coin150Button.GetComponent<Button>().interactable = false;
                coin500Button.GetComponent<Button>().interactable = false;
            }
            else if (StaticVariables.CoinCount >= 100 && StaticVariables.CoinCount < 150)
            {
                coin100Button.GetComponent<Button>().interactable = true;
                coin150Button.GetComponent<Button>().interactable = false;
                coin500Button.GetComponent<Button>().interactable = false;
            }
            else if (StaticVariables.CoinCount >= 150 && StaticVariables.CoinCount < 500)
            {
                coin100Button.GetComponent<Button>().interactable = true;
                coin150Button.GetComponent<Button>().interactable = true;
                coin500Button.GetComponent<Button>().interactable = false;
            }
            else if (StaticVariables.CoinCount >= 500)
            {
                coin100Button.GetComponent<Button>().interactable = true;
                coin150Button.GetComponent<Button>().interactable = true;
                coin500Button.GetComponent<Button>().interactable = true;
            }

            if (startNode.activeSelf == false)
            {
                coin150Button.GetComponent<Button>().interactable = false;
            }
        }
        
    }

    public void RestartBonBon()
    {
        if (StaticVariables.CoinCount >= 100)
        {
            UpdateCoins(100);
            shopMenu.SetActive(false);
            DataToCSV.RestartBonBonLine(StaticVariables.Level.ToString());
        }
    }

    public void StartNodeToffee()
    {
        if (startNode.activeSelf == true && StaticVariables.CoinCount >= 150)
        {
            UpdateCoins(150);
            shopMenu.SetActive(false);

            this.gameObject.GetComponent<LevelController>().ReplaceNode(firstRule.GetComponent<RuleContents>().GetCreatureImage(), startNode.GetComponent<RectTransform>().transform.position);
            this.gameObject.GetComponent<LevelController>().GetContents(firstRule.GetComponent<RuleContents>().GetRuleImages(), startNode.gameObject, startNode.GetComponent<RectTransform>().transform.localPosition.y);
            startNode.SetActive(false);
            DataToCSV.StartNodeToffeeLine(StaticVariables.Level.ToString(), this.gameObject.GetComponent<EndWord>().GetCurrentEndWordNames());
        }
    }

    public void DelayBusterTruffle()
    {
        if (StaticVariables.CoinCount >= 200)
        {
            UpdateCoins(200);
            shopMenu.SetActive(false);
            this.gameObject.GetComponent<LevelController>().AddLife();
            DataToCSV.DelayTruffleLine(StaticVariables.Level.ToString());
        }
    }

    public void RemovalRhubarb()
    {
        if (StaticVariables.CoinCount >= 500)
        {
            UpdateCoins(500);
            shopMenu.SetActive(false);
            for (int i = 0; i < listOfUnNeededRules.Count; i++)
            {
                listOfUnNeededRules[i].SetActive(false);
            }
            if (listOfUnNeededRules.Count == 0)
                this.gameObject.GetComponent<AllRulesNeeded>().OnAllRulesNeeded();
            DataToCSV.RemovalRhubarb(StaticVariables.Level.ToString());
        }
    }

    void UpdateCoins(int price)
    {
        int newScore = StaticVariables.CoinCount - price;
        StaticVariables.CoinCount = newScore;
        PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount);
    }
}
