using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleViewport : MonoBehaviour
{
    public GameObject contentScaler;


    public void ScaleTreeSize(float newWidth, float newHeight, float anchoredPositionY)
    {
        contentScaler.transform.DetachChildren();
        contentScaler.GetComponent<RectTransform>().sizeDelta = new Vector2(newWidth, newHeight);
        contentScaler.GetComponent<RectTransform>().anchoredPosition = new Vector2(contentScaler.GetComponent<RectTransform>().anchoredPosition.x, anchoredPositionY);
    }
}
