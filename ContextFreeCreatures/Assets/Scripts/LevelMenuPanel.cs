using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuPanel : MonoBehaviour
{
    public GameObject popUp;
    public GameObject exitMenu;
    public GameObject settingsMenu;
    public GameObject shopMenu;
    public GameObject infoPopUp;
    public GameObject startAnime;
    public GameObject hintPopUp;

    // Start is called before the first frame update
    void Start()
    {
        if (StaticVariables.ShouldPlayStartAnime == 1)
            PlayStartAnimation();
        settingsMenu.SetActive(false);
        exitMenu.SetActive(false);
        popUp.SetActive(false);
        infoPopUp.SetActive(false);
        hintPopUp.SetActive(false);
        shopMenu.SetActive(false);
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
    }

    void PlayStartAnimation()
    {
        startAnime.SetActive(true);
        var transform = startAnime.transform;
        foreach (Transform child in transform)
        {
            if (child.name == "Mandy")
            {
                child.GetComponent<Animator>().enabled = true;
                child.GetComponent<Animator>().Play("Mandy");
            }
            else if (child.name == "Speech")
            {
                child.GetComponent<Animator>().enabled = true;
                child.GetComponent<Animator>().Play("Speech");
            }
        }
        StaticVariables.ShouldPlayStartAnime = 0;
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

    public void OnHintButtonClick()
    {
        if (!this.gameObject.GetComponent<LevelController>().isLevelEnd)
        {
            if (hintPopUp.activeSelf == false)
                hintPopUp.SetActive(true);
            else
                hintPopUp.SetActive(false);
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
