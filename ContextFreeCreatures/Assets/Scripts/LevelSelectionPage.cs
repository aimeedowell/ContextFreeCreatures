using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionPage : MonoBehaviour
{
    private GameObject level1;
    private GameObject level2;
    private GameObject level3;
    private GameObject level4;
    private GameObject level5;

    public GameObject level1Button;
    public GameObject level2Button;
    public GameObject level3Button;
    public GameObject level4Button;
    public GameObject level5Button;

    // Start is called before the first frame update
    void Start()
    {
        level1 = GameObject.Find("Level 1 Panel");
        level2 = GameObject.Find("Level 2 Panel");
        level3 = GameObject.Find("Level 3 Panel");
        level4 = GameObject.Find("Level 4 Panel");
        level5 = GameObject.Find("Level 5 Panel");

        StaticVariables.Level1Stars = PlayerPrefs.GetInt("Level1Stars");
        StaticVariables.Level2Stars = PlayerPrefs.GetInt("Level2Stars");
        StaticVariables.Level3Stars = PlayerPrefs.GetInt("Level3Stars");
        StaticVariables.Level4Stars = PlayerPrefs.GetInt("Level4Stars");
        StaticVariables.Level5Stars = PlayerPrefs.GetInt("Level5Stars");
        
        SetStars();
        SetButtonStates();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetButtonStates()
    {
        if (StaticVariables.Level1Stars != 0)
        {
            level1.transform.Find("DoneTag").gameObject.SetActive(true);
            level2Button.GetComponent<Button>().interactable = true;
        }
        else
            level2Button.GetComponent<Button>().interactable = false;

        if (StaticVariables.Level2Stars != 0)
        {
            level2.transform.Find("DoneTag").gameObject.SetActive(true);
            level3Button.GetComponent<Button>().interactable = true;
        }
        else
            level3Button.GetComponent<Button>().interactable = false;

        if (StaticVariables.Level3Stars != 0)
        {
            level3.transform.Find("DoneTag").gameObject.SetActive(true);
            level4Button.GetComponent<Button>().interactable = true;
        }
        else
            level4Button.GetComponent<Button>().interactable = false;

        if (StaticVariables.Level4Stars != 0)
        {
            level4.transform.Find("DoneTag").gameObject.SetActive(true);
            level5Button.GetComponent<Button>().interactable = true;
        }
        else
            level5Button.GetComponent<Button>().interactable = false;

        if (StaticVariables.Level5Stars != 0)
        {
            level5.transform.Find("DoneTag").gameObject.SetActive(true);
        }
    }
    void SetStars()
    {
        // Level 1
        for (int i = 0; i < PlayerPrefs.GetInt("Level1Stars"); i++)
        {
            
            Transform stars = level1.transform.Find("Stars");
            if (i == 0)
                stars.transform.Find("Star1").gameObject.SetActive(true);
            else if (i == 1)
                stars.transform.Find("Star2").gameObject.SetActive(true);
            else if (i == 2)
                stars.transform.Find("Star3").gameObject.SetActive(true);
        }   
        // Level 2
        for (int i = 0; i < PlayerPrefs.GetInt("Level2Stars"); i++)
        {
            
            Transform stars = level2.transform.Find("Stars");
            if (i == 0)
                stars.transform.Find("Star1").gameObject.SetActive(true);
            else if (i == 1)
                stars.transform.Find("Star2").gameObject.SetActive(true);
            else if (i == 2)
                stars.transform.Find("Star3").gameObject.SetActive(true);
        }  
        // Level 3
        for (int i = 0; i < PlayerPrefs.GetInt("Level3Stars"); i++)
        {
            
            Transform stars = level3.transform.Find("Stars");
            if (i == 0)
                stars.transform.Find("Star1").gameObject.SetActive(true);
            else if (i == 1)
                stars.transform.Find("Star2").gameObject.SetActive(true);
            else if (i == 2)
                stars.transform.Find("Star3").gameObject.SetActive(true);
        }  
        // Level 4
        for (int i = 0; i < PlayerPrefs.GetInt("Level4Stars"); i++)
        {
            
            Transform stars = level4.transform.Find("Stars");
            if (i == 0)
                stars.transform.Find("Star1").gameObject.SetActive(true);
            else if (i == 1)
                stars.transform.Find("Star2").gameObject.SetActive(true);
            else if (i == 2)
                stars.transform.Find("Star3").gameObject.SetActive(true);
        }  
        // Level 5
        for (int i = 0; i < PlayerPrefs.GetInt("Level5Stars"); i++)
        {
            
            Transform stars = level5.transform.Find("Stars");
            if (i == 0)
                stars.transform.Find("Star1").gameObject.SetActive(true);
            else if (i == 1)
                stars.transform.Find("Star2").gameObject.SetActive(true);
            else if (i == 2)
                stars.transform.Find("Star3").gameObject.SetActive(true);
        }  

        // Add the same for each level
    }
            
}
