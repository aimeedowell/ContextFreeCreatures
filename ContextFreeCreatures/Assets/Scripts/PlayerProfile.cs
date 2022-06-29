using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    public GameObject playerProfile;

    public Slider slider;
    public Text noOfStars;
    public Text noOfBadges;
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
    }

    void SetStarValue()
    {
        int count = StaticVariables.Level1Stars + StaticVariables.Level2Stars + StaticVariables.Level3Stars +
                    StaticVariables.Level4Stars + StaticVariables.Level5Stars + StaticVariables.Level6Stars + 
                    StaticVariables.Level7Stars + StaticVariables.Level8Stars + StaticVariables.Level9Stars +
                    StaticVariables.Level10Stars;
        noOfStars.GetComponent<Text>().text = count.ToString();
    }
    void SetBadgeValue()
    {
        int count = StaticVariables.BadgeSymmetry + StaticVariables.BadgeEmptyWord + StaticVariables.BadgeSplit +
                    StaticVariables.BadgeTimer + StaticVariables.BadgeColourNodes;
        noOfBadges.GetComponent<Text>().text = count.ToString();
    }

}
