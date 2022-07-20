using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("VolumeLevel"))
            StaticVariables.VolumeLevel = PlayerPrefs.GetFloat("VolumeLevel");
        else
            StaticVariables.VolumeLevel = 1f;
        if (PlayerPrefs.HasKey("MusicVolumeLevel"))
            StaticVariables.MusicVolumeLevel = PlayerPrefs.GetFloat("MusicVolumeLevel");
        else
            StaticVariables.MusicVolumeLevel = 1f;
        StaticVariables.MaxReachedLevel = PlayerPrefs.GetInt("MaxReachedLevel");
        StaticVariables.HasGameCompleted = PlayerPrefs.GetInt("HasGameCompleted");
    }
}
