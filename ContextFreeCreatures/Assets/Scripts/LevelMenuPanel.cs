using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            else if (child.name == "Intro")
            {
                var chiChil = child.transform;
                foreach (Transform chi in chiChil)
                {
                    if (chi.name == "Image")
                    {
                        chi.GetComponent<Animator>().enabled = true;
                        chi.GetComponent<Animator>().Play(0);
                    }
                    else
                    {
                        chi.GetComponent<Animator>().enabled = true;
                        chi.GetComponent<Animator>().Play(0);
                    }
                }
            }
        }
        StaticVariables.ShouldPlayStartAnime = 0;
    }
    
    public void OnInfoButtonClick()
    {
        if (infoPopUp.activeSelf == false)
            infoPopUp.SetActive(true);
        else
            infoPopUp.SetActive(false);  

        int noOfStars = GetNumberOfStars();
        string newText = "Try a more efficient route, in a quicker time!";
        if (noOfStars == 2)
            newText = "Try a more efficient route or be quicker!";
        else if (noOfStars == 3)
            newText = "You found the most efficient route in a speedy time!";
        infoPopUp.transform.Find("Text").GetComponent<Text>().text = newText.ToString();
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

    int GetNumberOfStars()
    {
        switch(StaticVariables.Level) 
        {
            case 1:
                return StaticVariables.Level1Stars;
            case 2:
                return StaticVariables.Level2Stars;
            case 3:
                return StaticVariables.Level3Stars;
            case 4:
                return StaticVariables.Level4Stars;
            case 5:
                return StaticVariables.Level5Stars;
            case 6:
                return StaticVariables.Level6Stars;
            case 7:
                return StaticVariables.Level7Stars;
            case 8:
                return StaticVariables.Level8Stars;
            case 9:
                return StaticVariables.Level9Stars;
            case 10:
                return StaticVariables.Level10Stars;
        }
        return 0;
    }


}
