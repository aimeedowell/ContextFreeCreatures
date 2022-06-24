using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frozen : MonoBehaviour
{
    public GameObject frozenGem;

    List<GameObject> frozenItems = new List<GameObject>();

    List<GameObject> frozenImages = new List<GameObject>();

    float freezeTime = 6f;    

    public void AddFrozenGem(GameObject orginalGem, GameObject treeArea, Canvas canvas, Vector2 anchPos)
    {
        if (!orginalGem.name.Contains("Node"))
        {
            GameObject frozen = Instantiate(frozenGem, canvas.transform);
            frozen.GetComponent<RectTransform>().anchoredPosition = anchPos;
            frozen.transform.SetParent(treeArea.transform);
            frozen.SetActive(true);

            StartCoroutine(FadeFrozenGemIn(frozen, freezeTime));
            StartCoroutine(FadeGemOut(orginalGem, freezeTime));
        }
    }

    IEnumerator FadeFrozenGemIn(GameObject gem, float duration) 
    {
        var image = gem.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0f;
        var start = tempColor;
        tempColor.a = 1f;
        var end = tempColor;

        for (float t = 0f; t<duration; t+=Time.deltaTime) 
        {
            if (!this.gameObject.GetComponent<LevelController>().isLevelEnd)
            {
                float normalizedTime = t/duration;
                //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
                gem.GetComponent<Image>().color = Color.Lerp(start, end, normalizedTime);
                yield return null;
            }
        }
        if (!this.gameObject.GetComponent<LevelController>().isLevelEnd)
        {
            gem.GetComponent<Image>().color = end; 
            frozenImages.Add(gem);
        }
    }

    IEnumerator FadeGemOut(GameObject gem, float duration) 
    {
        var image = gem.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 1f;
        var start = tempColor;
        tempColor.a = 0f;
        var end = tempColor;

        for (float t = 0f; t<duration; t+=Time.deltaTime) 
        {
            if (!this.gameObject.GetComponent<LevelController>().isLevelEnd)
            {
                float normalizedTime = t/duration;
                gem.GetComponent<Image>().color = Color.Lerp(start, end, normalizedTime);
                yield return null;
            }
        }
        if (!this.gameObject.GetComponent<LevelController>().isLevelEnd)
        {
            gem.GetComponent<Image>().color = end; 
            frozenItems.Add(gem);
        }
    }

    public bool IsGemFrozen(GameObject gem)
    {
        if (frozenItems.Contains(gem))
            return true;
        else
            return false;
    }

    public void PlayFreezeAnimation(GameObject gemToFind)
    {
        // We know item is in array as we check this in EndWord.cs
        int index = frozenItems.IndexOf(gemToFind);
        frozenImages[index].GetComponent<Animator>().enabled = true;
        frozenImages[index].GetComponent<Animator>().Play("FrozenExplosion");
        // frozenImages[index].GetComponent<AudioSource>().Play(0);
    }
}
