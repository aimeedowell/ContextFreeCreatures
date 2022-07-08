using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllRulesNeeded : MonoBehaviour
{
    public GameObject item;
    public GameObject text;

    void Start() 
    {
        item.SetActive(false);
    }

    public void OnAllRulesNeeded()
    {
        item.SetActive(true);
        text.GetComponent<Text>().CrossFadeAlpha(1.0f, 0.5f, false); //fade out
        text.GetComponent<Text>().CrossFadeAlpha(0.0f, 1.5f, false); //fade out
    }
}
