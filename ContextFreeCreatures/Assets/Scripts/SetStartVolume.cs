using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StaticVariables.VolumeLevel = 0.5f;
         #if DEVELOPMENT_BUILD
            PlayerPrefs.DeleteAll(); // DELETE BEFORE BUILDING FOR REAL 
         #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
