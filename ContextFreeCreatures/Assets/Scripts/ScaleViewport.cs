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
        
        float difference = newHeight - oldHeight;

        contentScaler.transform.DetachChildren();

        contentScaler.GetComponent<RectTransform>().sizeDelta = new Vector2(contentScaler.GetComponent<RectTransform>().sizeDelta.x, newHeight);
        contentScaler.GetComponent<RectTransform>().anchoredPosition = new Vector2(contentScaler.GetComponent<RectTransform>().anchoredPosition.x, -difference/2);
        // contentScaler.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, -(newHeight-oldHeight)/2);
        // contentScaler.GetComponent<RectTransform>().anchoredPosition = new Vector2(contentScaler.GetComponent<RectTransform>().localPosition.x, 
        //                                                     contentScaler.GetComponent<RectTransform>().localPosition.y - (newHeight/2));
        Debug.Log ("outline y pos:" + contentScaler.GetComponent<RectTransform>().anchoredPosition.y);

    }

}
