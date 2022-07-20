using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComplete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        if (StaticVariables.Level15Stars != 0 && StaticVariables.HasGameCompleted == 0)
        {
            StaticVariables.HasGameCompleted = 1;
            PlayerPrefs.SetInt("HasGameCompleted", 1);
            this.gameObject.SetActive(true);
        }
    }
}
