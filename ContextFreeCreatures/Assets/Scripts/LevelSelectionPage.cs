using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionPage : MonoBehaviour
{
    private GameObject level1;
    private GameObject level2;
    private GameObject level3;
    private GameObject level4;
    private GameObject level5;

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
            
            Transform stars = level1.transform.Find("Stars");
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
            
            Transform stars = level1.transform.Find("Stars");
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
            
            Transform stars = level1.transform.Find("Stars");
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
            
            Transform stars = level1.transform.Find("Stars");
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
