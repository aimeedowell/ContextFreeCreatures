using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropToNode : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData data)
    {
        // Debug.Log("On Drop");
        if (data.pointerDrag != null)
        {
            data.pointerDrag.GetComponent<RectTransform>().transform.position = GetComponent<RectTransform>().transform.position;
            data.pointerDrag.GetComponent<DragAndDrop>().hasDropped = true;
            this.gameObject.SetActive(false);
            data.pointerDrag.GetComponent<LevelController>().ReplaceNode(GetComponent<RectTransform>().anchoredPosition);

            var rectTransform = GetComponent<RectTransform>();
            float height = GetComponent<RectTransform>().transform.localPosition.y;
            float width = GetComponent<RectTransform>().transform.localPosition.x;
            data.pointerDrag.GetComponent<LevelController>().GetContents(height);
            
        }
    }
}
