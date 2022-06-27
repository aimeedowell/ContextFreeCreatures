using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDigging : MonoBehaviour
{
    public GameObject lineImage;

    public GameObject lineImageContainer;

    public GameObject maskContainer;
    public GameObject mask;
    GameObject start;
    GameObject end;
    public Canvas canvas;

    public void DrawLine(GameObject startObj, GameObject endObj)
    {
        start = startObj;
        end = endObj;

        GameObject lineContain = Instantiate(lineImageContainer, canvas.transform);
        GameObject maskContain = Instantiate(mask, canvas.transform);
        lineContain.transform.SetParent(maskContain.transform);
        maskContain.transform.SetParent(maskContainer.transform);
        lineContain.SetActive(true);
        lineContain.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        

        GetAngle(lineContain);
        lineContain.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(lineContain.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x, GetHeightDistance());
        lineContain.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(0, -GetHeightDistance()/2, 0);;
        lineContain.GetComponent<RectTransform>().transform.position = start.GetComponent<RectTransform>().transform.position; 

        float lengthOfMask = 300f;

        Vector2 endSize = new Vector2(maskContain.GetComponent<RectTransform>().sizeDelta.x, lengthOfMask);

        float startY = start.transform.localPosition.y;
        float startX = start.transform.localPosition.x;
        Vector2 startAnch = new Vector2(startX, startY);
        Vector2 endAnch = new Vector2(startX, startY - (lengthOfMask/2));
        // Vector3 endSize = 650;
        maskContain.GetComponent<RectTransform>().anchoredPosition = startAnch;
        maskContain.SetActive(true);
        // maskContain.GetComponent<Animator>().Play("MaskingLine");

        StartCoroutine(MoveMask(lineContain, maskContain, endSize, endAnch, 3f));
    }

    IEnumerator MoveMask(GameObject line, GameObject mask, Vector2 endSize, Vector2 endAnch, float timeToMove)
    {
        var currentSize = mask.GetComponent<RectTransform>().sizeDelta;
        var currentPos = mask.GetComponent<RectTransform>().anchoredPosition;
        var t = 0f;
        while(t < 1)
        {
            line.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            t += Time.deltaTime / timeToMove;
            mask.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(currentSize, endSize, t);
            mask.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(currentPos, endAnch, t);
            yield return null;
        }
    }

    void GetAngle(GameObject contain)
    {
        contain.transform.rotation = Quaternion.FromToRotation(Vector3.up, start.transform.localPosition - end.transform.localPosition);
    }

    float GetHeightDistance()
    {
        double y1 = start.transform.localPosition.y;
        double y2 = end.transform.localPosition.y;
        double x1 = start.transform.localPosition.x;
        double x2 = end.transform.localPosition.x;
        double power = 2;

        double arg1 = Math.Pow((x2-x1), power);
        double arg2 = Math.Pow((y2-y1), power);

        return Mathf.Sqrt((float)arg1 + (float)arg2);
    }

}
