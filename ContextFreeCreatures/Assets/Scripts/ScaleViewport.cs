using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleViewport : MonoBehaviour
{
    public GameObject contentScaler;


    public void ScaleTreeSizeWidth(float newWidth, float newHeight, float anchoredPositionY)
    {
        contentScaler.transform.DetachChildren();
        contentScaler.GetComponent<RectTransform>().sizeDelta = new Vector2(newWidth, newHeight);
        contentScaler.GetComponent<RectTransform>().anchoredPosition = new Vector2(contentScaler.GetComponent<RectTransform>().anchoredPosition.x, anchoredPositionY);
    }
    
    public void ScaleTreeSizeHeight(float oldHeight, float newHeight)
    {
        contentScaler.transform.DetachChildren();
        float startY = contentScaler.transform.localPosition.y;
        float startX = contentScaler.transform.localPosition.x;

        contentScaler.GetComponent<RectTransform>().sizeDelta = new Vector2(contentScaler.GetComponent<RectTransform>().sizeDelta.x, newHeight);
        Vector2 endAnch = new Vector2(startX, startY - (newHeight/2));
    }
}
