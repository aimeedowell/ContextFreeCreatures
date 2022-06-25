using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text coinScore;
    public GameObject shopMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartBonBon()
    {
        int newScore = StaticVariables.CoinCount - 100;
        StaticVariables.CoinCount = newScore;
        PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount);

        shopMenu.SetActive(false);
    }
}
