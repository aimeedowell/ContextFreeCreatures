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
        if (StaticVariables.Level == 1)
        {
            if (PlayerPrefs.GetInt("BadgeSymmetry") == 0)
            {   
                SetBadgeUI();
                StaticVariables.BadgeSymmetry = 1;
                PlayerPrefs.SetInt("BadgeSymmetry", StaticVariables.BadgeSymmetry);
            }
        }
        else if (StaticVariables.Level == 2)
        {
            if (PlayerPrefs.GetInt("BadgeEmptyWord") == 0)
            {
                SetBadgeUI();
                StaticVariables.BadgeEmptyWord = 1;
                PlayerPrefs.SetInt("BadgeEmptyWord", StaticVariables.BadgeEmptyWord);
            }
        }
        else if (StaticVariables.Level == 7)
        {
            if (PlayerPrefs.GetInt("BadgeTimer") == 0)
            {
                SetBadgeUI();
                StaticVariables.BadgeTimer = 1;
                PlayerPrefs.SetInt("BadgeTimer", StaticVariables.BadgeTimer);
            }
        }
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
