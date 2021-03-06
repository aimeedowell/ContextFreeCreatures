using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropToNode : MonoBehaviour, IDropHandler
{
    GameObject cam;

    private void Start() 
    {
        cam = GameObject.Find("Main Camera");    
    }

    public void OnDrop(PointerEventData data)
    {
        if (data.pointerDrag != null && data.pointerDrag.gameObject.name != "View")
        {
            if (StaticVariables.CurrentLevel >= 9)
            {
                var childElement = data.pointerDrag.gameObject.transform.GetChild(0);
                if (!childElement.name.Contains("Red") && this.gameObject.name.Contains("Start"))
                {
                    MouseClickSoundManager.PlayMouseError();
                    return;
                }
                else if (!childElement.name.Contains("Blue") && this.gameObject.name.Contains("Blue"))
                {
                    MouseClickSoundManager.PlayMouseError();
                    return;
                }
                else if (!childElement.name.Contains("Yellow") && this.gameObject.name.Contains("Yellow"))
                {
                    MouseClickSoundManager.PlayMouseError();
                    return;
                }
                else if (!childElement.name.Contains("Pink") && this.gameObject.name.Contains("Pink"))
                {
                    MouseClickSoundManager.PlayMouseError();
                    return;
                }
                else if (!childElement.name.Contains("Green") && this.gameObject.name.Contains("Green"))
                {
                    MouseClickSoundManager.PlayMouseError();
                    return;
                }
            }
            data.pointerDrag.GetComponent<RectTransform>().transform.position = GetComponent<RectTransform>().transform.position;
            data.pointerDrag.GetComponent<DragAndDrop>().hasDropped = true;
            this.gameObject.SetActive(false);
            cam.GetComponent<LevelController>().ReplaceNode(data.pointerDrag.GetComponent<RuleContents>().GetCreatureImage(), GetComponent<RectTransform>().transform.position);


            float height = GetComponent<RectTransform>().transform.localPosition.y;
            float width = GetComponent<RectTransform>().transform.localPosition.x;

            cam.GetComponent<LevelController>().GetContents(data.pointerDrag.GetComponent<RuleContents>().GetRuleImages(), this.gameObject, height);
            data.pointerDrag.SetActive(false);
        }
    }
}
