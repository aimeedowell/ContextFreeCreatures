using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StaticVariables.VolumeLevel = 1.0f;
        StaticVariables.MusicVolumeLevel = 1.0f;
        StaticVariables.MaxReachedLevel = PlayerPrefs.GetInt("MaxReachedLevel");
    }
}
