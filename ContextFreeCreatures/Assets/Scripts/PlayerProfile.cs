using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    public GameObject playerProfile;
    public GameObject cup;

    public Slider slider;
    public Text noOfStars;
    public Text noOfBadges;

    public Text skillLevel;
    public Sprite silverCup;
    public Sprite goldCup;

    int maxLevel = 0;
    int maxStars = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerProfile.SetActive(false);
    }

    public void OnProfileButtonClick()
    {
        playerProfile.SetActive(true);
        SetLevelSliderValue();
        SetStarValue();
        SetBadgeValue();
        SetPlayerSkillLevel(maxLevel);
    }

    public void OnProfileExitClick()
    {
        playerProfile.SetActive(false);
    }

    void SetLevelSliderValue()
    {
        //  Find max level... 
        int val = this.gameObject.GetComponent<LevelSelectionPage>().maxLevel;
        slider.value = val;
        maxLevel = val;
    }

    public void SetStarValue()
    {
        int count = StaticVariables.Level1Stars + StaticVariables.Level2Stars + StaticVariables.Level3Stars +
                    StaticVariables.Level4Stars + StaticVariables.Level5Stars + StaticVariables.Level6Stars + 
                    StaticVariables.Level7Stars + StaticVariables.Level8Stars + StaticVariables.Level9Stars +
                    StaticVariables.Level10Stars;
        noOfStars.GetComponent<Text>().text = count.ToString();
        maxStars = count;
    }
    void SetBadgeValue()
    {
        int count = StaticVariables.BadgeSymmetry + StaticVariables.BadgeEmptyWord + StaticVariables.BadgeSplit +
                    StaticVariables.BadgeTimer + StaticVariables.BadgeColourNodes;
        noOfBadges.GetComponent<Text>().text = count.ToString();
    }

    public void SetPlayerSkillLevel(int maxLevel)
    {
        string skill = "Newbie";
        if ((maxLevel >= 0 && maxLevel < 3) && (maxStars >= 0 && maxStars < 6))
            skill = "Newbie";
        else if ((maxLevel >= 3 && maxLevel < 7) && (maxStars >= 6 && maxStars < 21))
            skill = "Rookie";
        else if ((maxLevel >= 7 && maxLevel < 10) && (maxStars >= 21 && maxStars < 25))
        {
            skill = "Intermediate";
            cup.GetComponent<Image>().sprite = silverCup;
        }
        else if (maxLevel == 10 && (maxStars <= 25))
        {
            skill = "Expert";
            GetComponent<Image>().sprite = goldCup;
        }
        else if (maxLevel == 10 && (maxStars >= 25 && maxStars <= 30))
        {
            skill = "Master";
            GetComponent<Image>().sprite = goldCup;
        }
        skillLevel.GetComponent<Text>().text = skill; 
        StaticVariables.PlayerSkillLevel = skill;

    }

}
