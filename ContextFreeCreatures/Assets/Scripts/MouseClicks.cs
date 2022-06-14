using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClicks : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData data)
    {
        MouseClickSoundManager.PlayOnClick();
        // Debug.Log("Mouse Down");
    }

    public void OnPointerUp(PointerEventData data)
    {
        MouseClickSoundManager.PlayClickUp();
        // Debug.Log("Mouse Down");
    }

    public void OnPointerEnter(PointerEventData data)
    {
        MouseClickSoundManager.PlayHoverClick();
        // Debug.Log("Mouse Over");
    }

}
