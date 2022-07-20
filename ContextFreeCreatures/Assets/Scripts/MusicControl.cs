using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    public AudioMixer soundEffectMixer;
    public Slider soundEffectSlider;

    public AudioMixer musicMixer;
    public Slider musicSlider;

    void Start() 
    {
        // SOUND EFFECTS
        soundEffectSlider.value = StaticVariables.VolumeLevel;
        SetSoundEffectVolume(StaticVariables.VolumeLevel);

        if (StaticVariables.IsMuted == 1)
            SetMuted(true);

        // BACKGROUND MUSIC
        musicSlider.value = StaticVariables.MusicVolumeLevel;
        SetMusicVolume(StaticVariables.MusicVolumeLevel);

        if (StaticVariables.IsMusicMuted == 1)
            SetMusicMuted(true);
    }

// SOUND EFFECTS
    public void SetMuted(bool isMute)
    {
        if (isMute)
        {
            soundEffectSlider.interactable = false;
            soundEffectMixer.SetFloat("SliderLevel", (Mathf.Log10(0.0001f) * 20)); // So static variable does not change
            StaticVariables.IsMuted = 1;
            PlayerPrefs.SetFloat("VolumeLevel", 0.0001f);
        }
        else
        {
            SetSliderValue(StaticVariables.VolumeLevel);
            soundEffectSlider.interactable = true; 
            StaticVariables.IsMuted = 0;
        }        
    }

    public void SetSliderValue(float val)
    {
        soundEffectSlider.value = val;
        SetSoundEffectVolume(val);
    }

    public void SetSoundEffectVolume(float sliderVal)
    {
        float dbLevel = Mathf.Log10(sliderVal) * 20;
        StaticVariables.VolumeLevel = dbLevel;
        if (StaticVariables.IsMuted == 0)
        {
            soundEffectMixer.SetFloat("SliderLevel", dbLevel);
            PlayerPrefs.SetFloat("VolumeLevel", dbLevel);
        }
    }

// BACKGROUND MUSIC
    public void SetMusicMuted(bool isMute)
    {
        if (isMute)
        {
            musicSlider.interactable = false;
            musicMixer.SetFloat("MusicVolume", (Mathf.Log10(0.0001f) * 20)); // So static variable does not change
            PlayerPrefs.SetFloat("MusicVolumeLevel", 0.0001f);
            StaticVariables.IsMusicMuted = 1;
        }
        else
        {
            SetMusicSliderValue(StaticVariables.MusicVolumeLevel);
            musicSlider.interactable = true; 
            StaticVariables.IsMusicMuted = 0;
        }        
    }

    public void SetMusicSliderValue(float val)
    {
        musicSlider.value = val;
        SetMusicVolume(val);
    }

    public void SetMusicVolume(float sliderVal)
    {
        float dbLevel = Mathf.Log10(sliderVal) * 20;
        StaticVariables.MusicVolumeLevel = dbLevel;
        if (StaticVariables.IsMusicMuted == 0)
        {
            musicMixer.SetFloat("MusicVolume", dbLevel);
            PlayerPrefs.SetFloat("MusicVolumeLevel", dbLevel);
        }
    }
}
