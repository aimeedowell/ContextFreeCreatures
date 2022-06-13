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


    // Start is called before the first frame update
    void Start()
    {  
    }

    public void DrawLine(GameObject startObj, GameObject endObj)
    {
        start = startObj;
        end = endObj;

        GameObject lineContain = Instantiate(lineImageContainer, canvas.transform);
        GameObject maskContain = Instantiate(mask, canvas.transform);
        lineContain.transform.SetParent(maskContain.transform);
        maskContain.transform.SetParent(maskContainer.transform);
        lineContain.SetActive(true);
        

        GetAngle(lineContain);
        lineContain.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(lineContain.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x, GetHeightDistance());
        lineContain.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(0, -GetHeightDistance()/2, 0);;
        lineContain.GetComponent<RectTransform>().transform.position = start.GetComponent<RectTransform>().transform.position; 

        maskContain.SetActive(true);
        maskContain.GetComponent<Animator>().Play("MaskingLine");


    }
    void GetAngle(GameObject contain)
    {
        contain.transform.rotation = Quaternion.FromToRotation(Vector3.up, start.transform.position - end.transform.position);
    }

    float GetHeightDistance()
    {
        double y1 = start.transform.position.y;
        double y2 = end.transform.position.y;
        double x1 = start.transform.position.x;
        double x2 = end.transform.position.x;
        double power = 2;

        double arg1 = Math.Pow((x2-x1), power);
        double arg2 = Math.Pow((y2-y1), power);

        return Mathf.Sqrt((float)arg1 + (float)arg2);
    }

}
