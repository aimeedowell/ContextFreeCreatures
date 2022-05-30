using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector2 startPosition;
    private CanvasGroup canvasGroup;
    public bool hasDropped = false;

    private void Awake() 
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("Mouse Down");
    }

    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("Begin Drag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("Dragging");
        rectTransform.anchoredPosition += data.delta;
    }

    public void OnEndDrag(PointerEventData data)
    {
        Debug.Log("End Drag");
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        if (!hasDropped) 
            rectTransform.anchoredPosition = startPosition;
    }




}
