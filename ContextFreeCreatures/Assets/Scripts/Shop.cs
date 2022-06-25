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

    public void RestartBonBon()
    {
        UpdateCoins(100);
        shopMenu.SetActive(false);
    }

    public void StartNodeToffee()
    {
        if (startNode.activeSelf == true)
        {
            UpdateCoins(150);
            shopMenu.SetActive(false);

            this.gameObject.GetComponent<LevelController>().ReplaceNode(firstRule.GetComponent<RuleContents>().GetCreatureImage(), startNode.GetComponent<RectTransform>().anchoredPosition);
            this.gameObject.GetComponent<LevelController>().GetContents(firstRule.GetComponent<RuleContents>().GetRuleImages(), startNode.gameObject, startNode.GetComponent<RectTransform>().transform.localPosition.y);
            startNode.SetActive(false);
        }
    }

    void UpdateCoins(int price)
    {
        int newScore = StaticVariables.CoinCount - price;
        StaticVariables.CoinCount = newScore;
        PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount);
    }
}
