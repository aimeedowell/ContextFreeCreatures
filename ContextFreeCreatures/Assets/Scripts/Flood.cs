using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flood : MonoBehaviour
{
    public GameObject startNode;
    public GameObject maskContainer;
    public GameObject mask;
    public Text timerText;
    GameObject cam;
    GameObject treeArea;
    bool timerStarted = false;
    float amountOfTime = 50f;
    float timeRemaining = 50f;

    // Start is called before the first frame update
    void Start()
    {
        treeArea = GameObject.Find("TreeSpace");
        cam = GameObject.Find("Main Camera");

        if (StaticVariables.StartFlood == 1)
        {
            OnStartClicked();
            StaticVariables.StartFlood = 0;
        }
    }

// Countdown timer code adapted from French (2020).
// French, J., 2020. How to make a countdown timer in Unity (in minutes + seconds) [Online].
// Available from: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/#:~:text=Making%20a%20countdown%20timer%20in,need%20to%20be%20calculated%20individually. 
// [Accessed 1 June 2022].
    void Update()
    {
        if (timerStarted && !cam.GetComponent<LevelController>().isLevelEnd)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerStarted = false;
                cam.GetComponent<LevelEnd>().LevelFailed();
                Debug.Log("Time has run out!");
            }
            DisplayTime(timeRemaining);
        }
    }

    public void OnStartClicked()
    {
        timerStarted = true;
        maskContainer.SetActive(true);
        mask.SetActive(true);
        float lengthOfMask = treeArea.GetComponent<RectTransform>().rect.height;
        Vector2 endSize = new Vector2(mask.GetComponent<RectTransform>().sizeDelta.x, lengthOfMask);

        float startY = startNode.transform.localPosition.y;
        float startX = startNode.transform.localPosition.x;
        Vector2 startAnch = new Vector2(startX, startY);
        Vector2 endAnch = new Vector2(startX, startY - (lengthOfMask/2));

        mask.GetComponent<RectTransform>().anchoredPosition = startAnch;
        mask.SetActive(true);

        StartCoroutine(MoveMask(mask, endSize, endAnch, amountOfTime));
    }



    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}s", minutes, seconds);
    }

    IEnumerator MoveMask(GameObject mask, Vector2 endSize, Vector2 endAnch, float timeToMove)
    {
        var currentSize = mask.GetComponent<RectTransform>().sizeDelta;
        var currentPos = mask.GetComponent<RectTransform>().anchoredPosition;
        var t = 0f;
        while(t < 1 && !cam.GetComponent<LevelController>().isLevelEnd)
        {
            t += Time.deltaTime / timeToMove;
            mask.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(currentSize, endSize, t);
            mask.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(currentPos, endAnch, t);
            yield return null;
        }
    }
}
