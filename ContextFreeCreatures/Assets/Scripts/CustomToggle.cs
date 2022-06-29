using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomToggle : MonoBehaviour, IPointerDownHandler
{
    bool isOn = true;
    GameObject cam;
    public GameObject toggleOn;
    public GameObject toggleOff;
    public GameObject mutedImg;
    public GameObject unmutedImg;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        toggleOn.SetActive(true);
        unmutedImg.SetActive(true);
        toggleOff.SetActive(false);
        mutedImg.SetActive(false);

        if (StaticVariables.IsMuted == 1)
            MuteOffImage();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (isOn)
            MuteOffImage();
        else
            MuteOnImage();
    }

    void MuteOnImage()
    {
        isOn = true;
        cam.GetComponent<MusicControl>().SetMuted(false);
        cam.GetComponent<MusicControl>().SetSliderValue(StaticVariables.VolumeLevel);
        toggleOn.SetActive(true);
        unmutedImg.SetActive(true);
        toggleOff.SetActive(false);
        mutedImg.SetActive(false);
    }

    void MuteOffImage()
    {
        isOn = false;
        cam.GetComponent<MusicControl>().SetMuted(true);
        toggleOn.SetActive(false);
        unmutedImg.SetActive(false);
        toggleOff.SetActive(true);
        mutedImg.SetActive(true);
    }
}
