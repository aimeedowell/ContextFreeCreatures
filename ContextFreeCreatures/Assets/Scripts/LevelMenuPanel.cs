using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuPanel : MonoBehaviour
{

    public GameObject popUp;
    public GameObject exitMenu;
    public GameObject settingsMenu;
    public GameObject shopMenu;

    public GameObject infoButton;
    public GameObject infoPopUp;
    public GameObject startAnime;

    // Start is called before the first frame update
    void Start()
    {
        startAnime.SetActive(true);
        settingsMenu.SetActive(false);
        exitMenu.SetActive(false);
        popUp.SetActive(false);
        infoPopUp.SetActive(false);
        shopMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExitButtonClick()
    {
        if (!this.gameObject.GetComponent<LevelController>().isLevelEnd)
        {
            popUp.SetActive(true);
            exitMenu.SetActive(true);
        }
    }

    public void OnSettingsButtonClick()
    {
        if (!this.gameObject.GetComponent<LevelController>().isLevelEnd)
        {
            popUp.SetActive(true);
            settingsMenu.SetActive(true);
        }

    }

    public void OnResumeButtonClick()
    {
        popUp.SetActive(false);
        exitMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void OnQuitButtonClick()
    {
        popUp.SetActive(false);
        exitMenu.SetActive(false);
    }

    public void OnLetsGoClick()
    {
        startAnime.SetActive(false);
        // mandy&speech.GetComponent<Animator>().enabled = false;
    }
    
    public void OnInfoButtonClick()
    {
        if (!this.gameObject.GetComponent<LevelController>().isLevelEnd)
        {
            if (infoPopUp.activeSelf == false)
                infoPopUp.SetActive(true);
            else
                infoPopUp.SetActive(false);
        }
    }

    public void OnShopButtonClick()
    {
        if (!this.gameObject.GetComponent<LevelController>().isLevelEnd)
        {
            shopMenu.SetActive(true);
        }
    }


    public void OnShopExitClick()
    {
        shopMenu.SetActive(false);
    }

    public void DisableAllPopUps()
    {
        startAnime.SetActive(false);
        settingsMenu.SetActive(false);
        exitMenu.SetActive(false);
        popUp.SetActive(false);
        infoPopUp.SetActive(false);
        shopMenu.SetActive(false);
    }


}
