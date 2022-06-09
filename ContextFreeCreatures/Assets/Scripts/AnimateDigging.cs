using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDigging : MonoBehaviour
{
    public GameObject lineImage;

    public GameObject lineImageContainer;
    public GameObject start;
    public GameObject end;


    // Start is called before the first frame update
    void Start()
    {  
    }

    public void DrawLine(GameObject startObj, GameObject endObj)
    {
        start = startObj;
        end = endObj;
        lineImageContainer.SetActive(true);
        GetAngle();
        lineImage.GetComponent<RectTransform>().sizeDelta = new Vector2(10, GetHeightDistance());
        lineImage.GetComponent<RectTransform>().localPosition = new Vector3(0, -GetHeightDistance()/2, 0);;
        lineImageContainer.GetComponent<RectTransform>().transform.position = start.GetComponent<RectTransform>().transform.position; 
    }
    void GetAngle()
    {
        lineImageContainer.transform.rotation = Quaternion.FromToRotation(Vector3.up, start.transform.position - end.transform.position);
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
