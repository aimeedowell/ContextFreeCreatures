using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuPanel : MonoBehaviour
{

    public GameObject popUp;
    public GameObject exitMenu;
    // Start is called before the first frame update
    void Start()
    {
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

    public void OnResumeButtonClick()
    {
        popUp.SetActive(false);
        exitMenu.SetActive(false);
    }

    public void OnQuitButtonClick()
    {
        popUp.SetActive(false);
        exitMenu.SetActive(false);
    }


}
