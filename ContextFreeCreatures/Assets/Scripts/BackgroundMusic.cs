using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public GameObject music;

    void Awake() 
    {
        DontDestroyOnLoad(music);
    }

}
