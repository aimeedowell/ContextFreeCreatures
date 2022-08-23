using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TargetWordIntro;
    public GameObject TargetBubble1;
    public GameObject TargetBubble2;
    public GameObject CreatureIntro;
    public GameObject DragIntro;
    public GameObject DragOne;
    public GameObject DragTwo;
    public GameObject StartNode;
    public GameObject LevelComplete;
    bool levelComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        CreatureIntro.SetActive(false);
        DragIntro.SetActive(false);
        TargetWordIntro.SetActive(true);
        StaticVariables.NoOfLives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (DragIntro.activeSelf && !StartNode.activeSelf)
        {
            OnDragOneComplete();
        }

        if (LevelComplete.activeSelf && !levelComplete)
        {
            OnDragTwoComplete();
            levelComplete = true;
        }
    }

    public void OnTargetWordClick1()
    {
        TargetBubble1.SetActive(false);
        TargetBubble2.SetActive(true);
    }

    public void OnTargetWordClick2()
    {
        TargetWordIntro.SetActive(false);
        CreatureIntro.SetActive(true);
    }

    public void OnCreatureClick()
    {
        CreatureIntro.SetActive(false);
        DragIntro.SetActive(true);
        DragOne.SetActive(true);
        DragTwo.SetActive(false);
    }

    public void OnDragOneComplete()
    {
        DragOne.SetActive(false);
        DragTwo.SetActive(true);
    }

    public void OnDragTwoComplete()
    {
        DragOne.SetActive(false);
        DragTwo.SetActive(false);
        DragIntro.SetActive(false);
        PlayerPrefs.SetInt("TutorialComplete", 1);
    }
}
