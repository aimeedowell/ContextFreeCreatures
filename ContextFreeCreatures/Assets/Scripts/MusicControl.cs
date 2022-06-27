using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    bool isMuted = false;

    public void SetMuted(bool isMute)
    {
        isMuted = isMute;
        slider.value = 0f;
    }

    public void SetSliderValue(float val)
    {
        slider.value = val;
    }

    public void SetVolume(float sliderVal)
    {
        StaticVariables.VolumeLevel = sliderVal;
        if (!isMuted)
        {
            mixer.SetFloat("SliderLevel", (Mathf.Log10(sliderVal) * 20));
        }
    }
}
