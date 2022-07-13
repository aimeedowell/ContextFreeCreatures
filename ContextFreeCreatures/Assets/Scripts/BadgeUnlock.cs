using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgeUnlock : MonoBehaviour
{
    public GameObject badge;
    public GameObject background;
    public GameObject title;
    public GameObject image;
    public GameObject content;

    // Start is called before the first frame update
    void Start()
    {
        badge.SetActive(false);
    }

    public void ShowBadge()
    {
        if (StaticVariables.CurrentLevel == 1)
        {
            if (PlayerPrefs.GetInt("BadgeSymmetry") == 0)
            {   
                SetBadgeUI();
                StaticVariables.BadgeSymmetry = 1;
                PlayerPrefs.SetInt("BadgeSymmetry", StaticVariables.BadgeSymmetry);
            }
        }
        else if (StaticVariables.CurrentLevel == 2)
        {
            if (PlayerPrefs.GetInt("BadgeEmptyWord") == 0)
            {
                SetBadgeUI();
                StaticVariables.BadgeEmptyWord = 1;
                PlayerPrefs.SetInt("BadgeEmptyWord", StaticVariables.BadgeEmptyWord);
            }
        }
        else if (StaticVariables.CurrentLevel == 6)
        {
            if (PlayerPrefs.GetInt("BadgeSplit") == 0)
            {
                SetBadgeUI();
                StaticVariables.BadgeSplit = 1;
                PlayerPrefs.SetInt("BadgeSplit", StaticVariables.BadgeSplit);
            }
        }
        else if (StaticVariables.CurrentLevel == 7)
        {
            if (PlayerPrefs.GetInt("BadgeTimer") == 0)
            {
                SetBadgeUI();
                StaticVariables.BadgeTimer = 1;
                PlayerPrefs.SetInt("BadgeTimer", StaticVariables.BadgeTimer);
            }
        }
        else if (StaticVariables.CurrentLevel == 9)
        {
            if (PlayerPrefs.GetInt("BadgeColourNodes") == 0)
            {
                SetBadgeUI();
                StaticVariables.BadgeColourNodes = 1;
                PlayerPrefs.SetInt("BadgeColourNodes", StaticVariables.BadgeColourNodes);
            }
        }
        else if (StaticVariables.CurrentLevel == 14)
        {
            if (PlayerPrefs.GetInt("BadgeColourNodes") == 0)
            {
                SetBadgeUI();
                StaticVariables.BadgeMulticolour = 1;
                PlayerPrefs.SetInt("BadgeMulticolour", StaticVariables.BadgeMulticolour);
            }
        }
    }
    public bool BadgeToBeShown()
    {
        if (StaticVariables.CurrentLevel == 1)
        {
            if (PlayerPrefs.GetInt("BadgeSymmetry") == 0)
                return true;
        }
        else if (StaticVariables.CurrentLevel == 2)
        {
            if (PlayerPrefs.GetInt("BadgeEmptyWord") == 0)
                return true;
        }
        else if (StaticVariables.CurrentLevel == 6)
        {
            if (PlayerPrefs.GetInt("BadgeSplit") == 0)
                return true;
        }
        else if (StaticVariables.CurrentLevel == 7)
        {
            if (PlayerPrefs.GetInt("BadgeTimer") == 0)
                return true;
        }
        else if (StaticVariables.CurrentLevel == 9)
        {
            if (PlayerPrefs.GetInt("BadgeColourNodes") == 0)
                return true;
        }
        else if (StaticVariables.CurrentLevel == 14)
        {
            if (PlayerPrefs.GetInt("BadgeMulticolour") == 0)
                return true;
        }
        return false;
    }

    void SetBadgeUI()
    {
        badge.SetActive(true);
        StartCoroutine(FadeImageAlphaIn(background, 0f, 1f, 1f));
        StartCoroutine(FadeImageAlphaIn(image, 0f, 1f, 1f));
        title.GetComponent<Text>().CrossFadeAlpha(1.0f, 0f, false); //fade in
        title.GetComponent<Text>().CrossFadeAlpha(0.0f, 2.5f, false); //fade out

        content.GetComponent<Text>().CrossFadeAlpha(1.0f, 0f, false); //fade in
        content.GetComponent<Text>().CrossFadeAlpha(0.0f, 2.5f, false); //fade out
    }

    IEnumerator FadeImageAlphaIn(GameObject obj, float startAlpha, float endAlpha, float duration) 
    {
        var image = obj.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0f;
        var start = tempColor;
        tempColor.a = 1f;
        var end = tempColor;

        for (float t = 0f; t < duration; t += Time.deltaTime) 
        {
            float normalizedTime = t/duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            obj.GetComponent<Image>().color = Color.Lerp(start, end, normalizedTime);
            yield return null;
        }
        obj.GetComponent<Image>().color = end; //without this, the value will end at something like 0.9992367

        StartCoroutine(FadeImageAlphaOut(obj, endAlpha, startAlpha, 1f));
    }

    IEnumerator FadeImageAlphaOut(GameObject obj,float startAlpha, float endAlpha, float duration) 
    {
        yield return new WaitForSeconds(1f);

        var image = obj.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 1f;
        var start = tempColor;
        tempColor.a = 0f;
        var end = tempColor;

        for (float t = 0f; t < duration; t += Time.deltaTime) 
        {
            float normalizedTime = t/duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            obj.GetComponent<Image>().color = Color.Lerp(start, end, normalizedTime);
            yield return null;
        }
        obj.GetComponent<Image>().color = end; //without this, the value will end at something like 0.9992367
    }

}
