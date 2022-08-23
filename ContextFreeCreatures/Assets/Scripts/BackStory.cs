using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStory : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("TutorialComplete") == 1)
            SceneManager.LoadScene("StartPage");
        else
        {
            StaticVariables.VolumeLevel = 1f;
            PlayerPrefs.SetFloat("VolumeLevel", 1f);
            StaticVariables.MusicVolumeLevel = 1f;
            PlayerPrefs.SetFloat("MusicVolumeLevel", 1f);
            StartCoroutine(MoveScenes());
        }   
    }

    IEnumerator MoveScenes() 
    {
        yield return new WaitForSeconds(44f);
        SceneManager.LoadScene("StartPage");
    }

}
