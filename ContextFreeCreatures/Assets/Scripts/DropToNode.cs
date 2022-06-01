using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropToNode : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData data)
    {
        Debug.Log("On Drop");
        if (data.pointerDrag != null)
        {
            data.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            data.pointerDrag.GetComponent<DragAndDrop>().hasDropped = true;
            this.gameObject.SetActive(false);
            data.pointerDrag.GetComponent<GetRuleContents>().ReplaceNode(GetComponent<RectTransform>().anchoredPosition);
            data.pointerDrag.GetComponent<GetRuleContents>().GetContents();
            
        }
    }
}
