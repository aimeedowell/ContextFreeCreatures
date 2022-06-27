using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClicks : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
{

    public void OnPointerDown(PointerEventData data)
    {
        MouseClickSoundManager.PlayOnClick();
    }

    public void OnPointerUp(PointerEventData data)
    {
        MouseClickSoundManager.PlayClickUp();
    }

    public void OnPointerEnter(PointerEventData data)
    {
        MouseClickSoundManager.PlayHoverClick();
    }

}
