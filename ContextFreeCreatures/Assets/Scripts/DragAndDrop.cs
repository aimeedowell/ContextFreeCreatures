using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private RectTransform startPosition;

    private void Awake() 
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform;
    }

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("Mouse Down");
    }

    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("Begin Drag");
        
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("Dragging");
        rectTransform.anchoredPosition += data.delta;
    }

    public void OnEndDrag(PointerEventData data)
    {
        Debug.Log("End Drag");
    }

    public void OnDrop(PointerEventData data)
    {
        Debug.Log("End Drag");
    }


}
