using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickSoundManager : MonoBehaviour
{
    public static AudioClip onCLick;
    public static AudioClip offCLick;
    public static AudioClip hoverClick;
    public static AudioClip errorClick;


    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        onCLick = Resources.Load<AudioClip>("Audio/OnClick");
        offCLick = Resources.Load<AudioClip>("Audio/OffClick");
        hoverClick = Resources.Load<AudioClip>("Audio/HoverClick");
        errorClick = Resources.Load<AudioClip>("Audio/MouseError");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlayOnClick()
    {
        audioSrc.PlayOneShot(onCLick);
    }

    public static void PlayClickUp()
    {
        audioSrc.PlayOneShot(offCLick);
    }

    public static void PlayHoverClick()
    {
        audioSrc.PlayOneShot(hoverClick);
    }
    public static void PlayMouseError()
    {
        audioSrc.PlayOneShot(errorClick);
    }
}
