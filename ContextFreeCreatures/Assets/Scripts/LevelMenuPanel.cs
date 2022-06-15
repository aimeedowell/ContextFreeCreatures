using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuPanel : MonoBehaviour
{

    public GameObject popUp;
    public GameObject exitMenu;
    public GameObject settingsMenu;

    public GameObject startAnime;

    // Start is called before the first frame update
    void Start()
    {
        startAnime.SetActive(true);
        settingsMenu.SetActive(false);
        exitMenu.SetActive(false);
        popUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExitButtonClick()
    {
        popUp.SetActive(true);
        exitMenu.SetActive(true);

    }

    public void OnSettingsButtonClick()
    {
        popUp.SetActive(true);
        settingsMenu.SetActive(true);

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

}
