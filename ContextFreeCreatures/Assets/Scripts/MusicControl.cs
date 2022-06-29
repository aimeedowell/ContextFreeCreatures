using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start() 
    {
        slider.value = StaticVariables.VolumeLevel;
        SetVolume(StaticVariables.VolumeLevel);

        if (StaticVariables.IsMuted == 1)
            SetMuted(true);
    }

    public void SetMuted(bool isMute)
    {
        if (isMute)
        {
            slider.interactable = false;
            mixer.SetFloat("SliderLevel", (Mathf.Log10(0.0001f) * 20)); // So static variable does not change
            StaticVariables.IsMuted = 1;
        }
        else
        {
            SetSliderValue(StaticVariables.VolumeLevel);
            slider.interactable = true; 
            StaticVariables.IsMuted = 0;
        }        
    }

    public void SetSliderValue(float val)
    {
        slider.value = val;
        SetVolume(val);
    }

    public void SetVolume(float sliderVal)
    {
        StaticVariables.VolumeLevel = sliderVal;
        if (StaticVariables.IsMuted == 0)
        {
            mixer.SetFloat("SliderLevel", (Mathf.Log10(sliderVal) * 20));
        }
    }
}
