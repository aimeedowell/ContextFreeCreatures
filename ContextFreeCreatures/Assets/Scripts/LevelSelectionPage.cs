using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionPage : MonoBehaviour
{
    public Text noOfLives;
    public Text coinScore;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public GameObject level6;
    public GameObject level7;
    public GameObject level8;
    public GameObject level9;
    public GameObject level10;
    public GameObject level1Pin;
    public GameObject level2Pin;
    public GameObject level3Pin;
    public GameObject level4Pin;
    public GameObject level5Pin;
    public GameObject level6Pin;
    public GameObject level7Pin;
    public GameObject level8Pin;
    public GameObject level9Pin;
    public GameObject level10Pin;

    public GameObject areYouSure;
    public GameObject lostLivesPopUp;

    public int maxLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        noOfLives.GetComponent<Text>().text = PlayerPrefs.GetInt("Lives").ToString();
        StaticVariables.NoOfLives = PlayerPrefs.GetInt("Lives");
        coinScore.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
        StaticVariables.CoinCount = PlayerPrefs.GetInt("Coins");

        StaticVariables.Level1Stars = PlayerPrefs.GetInt("Level1Stars");
        StaticVariables.Level2Stars = PlayerPrefs.GetInt("Level2Stars");
        StaticVariables.Level3Stars = PlayerPrefs.GetInt("Level3Stars");
        StaticVariables.Level4Stars = PlayerPrefs.GetInt("Level4Stars");
        StaticVariables.Level5Stars = PlayerPrefs.GetInt("Level5Stars");
        StaticVariables.Level6Stars = PlayerPrefs.GetInt("Level6Stars");
        StaticVariables.Level7Stars = PlayerPrefs.GetInt("Level7Stars");
        StaticVariables.Level8Stars = PlayerPrefs.GetInt("Level8Stars");
        StaticVariables.Level9Stars = PlayerPrefs.GetInt("Level9Stars");
        StaticVariables.Level10Stars = PlayerPrefs.GetInt("Level10Stars");

        StaticVariables.BadgeColourNodes = PlayerPrefs.GetInt("BadgeColourNodes");
        StaticVariables.BadgeEmptyWord = PlayerPrefs.GetInt("BadgeEmptyWord");
        StaticVariables.BadgeSplit = PlayerPrefs.GetInt("BadgeSplit");
        StaticVariables.BadgeSymmetry = PlayerPrefs.GetInt("BadgeSymmetry");
        StaticVariables.BadgeTimer = PlayerPrefs.GetInt("BadgeTimer");

        StaticVariables.Level1Fails = PlayerPrefs.GetInt("Level1Fails");
        StaticVariables.Level2Fails = PlayerPrefs.GetInt("Level2Fails");
        StaticVariables.Level3Fails = PlayerPrefs.GetInt("Level3Fails");
        StaticVariables.Level4Fails = PlayerPrefs.GetInt("Level4Fails");
        StaticVariables.Level5Fails = PlayerPrefs.GetInt("Level5Fails");
        StaticVariables.Level6Fails = PlayerPrefs.GetInt("Level6Fails");
        StaticVariables.Level7Fails = PlayerPrefs.GetInt("Level7Fails");
        StaticVariables.Level8Fails = PlayerPrefs.GetInt("Level8Fails");
        StaticVariables.Level9Fails = PlayerPrefs.GetInt("Level9Fails");
        StaticVariables.Level10Fails = PlayerPrefs.GetInt("Level10Fails");

        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);
        level7.SetActive(false);
        level8.SetActive(false);
        level9.SetActive(false);
        level10.SetActive(false);

        areYouSure.SetActive(false);

        if (PlayerPrefs.GetInt("Lives") == 0)
        {
            AllLivesLost();
            lostLivesPopUp.SetActive(true);
        }
        else
            lostLivesPopUp.SetActive(false);
        
        SetPinStates();
        this.gameObject.GetComponent<PlayerProfile>().SetStarValue();
        this.gameObject.GetComponent<PlayerProfile>().SetPlayerSkillLevel(maxLevel);
    }

    void SetPinStates()
    {
        if (StaticVariables.Level1Stars != 0)
        {
            level1.transform.Find("DoneTag").gameObject.SetActive(true);
            level2Pin.SetActive(true);
            maxLevel = 1;
        }
        else
            level2Pin.SetActive(false);

        if (StaticVariables.Level2Stars != 0)
        {
            level2.transform.Find("DoneTag").gameObject.SetActive(true);
            level3Pin.SetActive(true);
            maxLevel = 2;
        }
        else
            level3Pin.SetActive(false);

        if (StaticVariables.Level3Stars != 0)
        {
            level3.transform.Find("DoneTag").gameObject.SetActive(true);
            level4Pin.SetActive(true);
            maxLevel = 3;
        }
        else
            level4Pin.SetActive(false);

        if (StaticVariables.Level4Stars != 0)
        {
            level4.transform.Find("DoneTag").gameObject.SetActive(true);
            level5Pin.SetActive(true);
            maxLevel = 4;
        }
        else
            level5Pin.SetActive(false);

        if (StaticVariables.Level5Stars != 0)
        {
            level5.transform.Find("DoneTag").gameObject.SetActive(true);
            level6Pin.SetActive(true);
            maxLevel = 5;
        }
        else
            level6Pin.SetActive(false);

        if (StaticVariables.Level6Stars != 0)
        {
            level6.transform.Find("DoneTag").gameObject.SetActive(true);
            level7Pin.SetActive(true);
            maxLevel = 6;
        }
        else
            level7Pin.SetActive(false);

        if (StaticVariables.Level7Stars != 0)
        {
            level7.transform.Find("DoneTag").gameObject.SetActive(true);
            level8Pin.SetActive(true);
            maxLevel = 7;
        }
        else
            level8Pin.SetActive(false);

        if (StaticVariables.Level8Stars != 0)
        {
            level8.transform.Find("DoneTag").gameObject.SetActive(true);
            level9Pin.SetActive(true);
            maxLevel = 8;
        }
        else
            level9Pin.SetActive(false);

        if (StaticVariables.Level9Stars != 0)
        {
            level9.transform.Find("DoneTag").gameObject.SetActive(true);
            level10Pin.SetActive(true);
            maxLevel = 9;
        }
        else
            level10Pin.SetActive(false);

        if (StaticVariables.Level10Stars != 0)
        {
            level10.transform.Find("DoneTag").gameObject.SetActive(true);
            maxLevel = 10;
        }
    }

    public void SetStars()
    {
        // Level 1
        for (int i = 0; i < PlayerPrefs.GetInt("Level1Stars"); i++)
        {
            
            var stars = level1.transform.Find("Stars");
            if (level1.activeSelf)
            {
                if (i == 0)
                    stars.transform.Find("Star1").gameObject.SetActive(true);
                else if (i == 1)
                    stars.transform.Find("Star2").gameObject.SetActive(true);
                else if (i == 2)
                    stars.transform.Find("Star3").gameObject.SetActive(true);
            }
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
        // Level 6
        for (int i = 0; i < PlayerPrefs.GetInt("Level6Stars"); i++)
        {
            
            Transform stars = level6.transform.Find("Stars");
            if (i == 0)
                stars.transform.Find("Star1").gameObject.SetActive(true);
            else if (i == 1)
                stars.transform.Find("Star2").gameObject.SetActive(true);
            else if (i == 2)
                stars.transform.Find("Star3").gameObject.SetActive(true);
        }  
        // Level 7
        for (int i = 0; i < PlayerPrefs.GetInt("Level7Stars"); i++)
        {
            
            Transform stars = level7.transform.Find("Stars");
            if (i == 0)
                stars.transform.Find("Star1").gameObject.SetActive(true);
            else if (i == 1)
                stars.transform.Find("Star2").gameObject.SetActive(true);
            else if (i == 2)
                stars.transform.Find("Star3").gameObject.SetActive(true);
        }
        // Level 8
        for (int i = 0; i < PlayerPrefs.GetInt("Level8Stars"); i++)
        {
            
            Transform stars = level8.transform.Find("Stars");
            if (i == 0)
                stars.transform.Find("Star1").gameObject.SetActive(true);
            else if (i == 1)
                stars.transform.Find("Star2").gameObject.SetActive(true);
            else if (i == 2)
                stars.transform.Find("Star3").gameObject.SetActive(true);
        }
        // Level 9
        for (int i = 0; i < PlayerPrefs.GetInt("Level9Stars"); i++)
        {
            
            Transform stars = level9.transform.Find("Stars");
            if (i == 0)
                stars.transform.Find("Star1").gameObject.SetActive(true);
            else if (i == 1)
                stars.transform.Find("Star2").gameObject.SetActive(true);
            else if (i == 2)
                stars.transform.Find("Star3").gameObject.SetActive(true);
        }
        // Level 10
        for (int i = 0; i < PlayerPrefs.GetInt("Level10Stars"); i++)
        {
            
            Transform stars = level10.transform.Find("Stars");
            if (i == 0)
                stars.transform.Find("Star1").gameObject.SetActive(true);
            else if (i == 1)
                stars.transform.Find("Star2").gameObject.SetActive(true);
            else if (i == 2)
                stars.transform.Find("Star3").gameObject.SetActive(true);
        }

        // Add the same for each level
    }

    void AllLivesLost()
    {
        if (StaticVariables.Level <= 3)
        {
            StaticVariables.Level1Stars = 0;
            StaticVariables.Level2Stars = 0;
            StaticVariables.Level3Stars = 0;

        }
        else if (StaticVariables.Level <= 6)
        {
            StaticVariables.Level4Stars = 0;
            StaticVariables.Level5Stars = 0;
            StaticVariables.Level6Stars = 0;
        }
        else if (StaticVariables.Level <= 10)
        {
            StaticVariables.Level7Stars = 0;
            StaticVariables.Level8Stars = 0;
            StaticVariables.Level9Stars = 0;
            StaticVariables.Level10Stars = 0;
        }
        StaticVariables.NoOfLives = 5;
        PlayerPrefs.SetInt("Lives", StaticVariables.NoOfLives);
    }

    public void CloseLostLivesPopUp()
    {
        lostLivesPopUp.SetActive(false);
    }
            
}
