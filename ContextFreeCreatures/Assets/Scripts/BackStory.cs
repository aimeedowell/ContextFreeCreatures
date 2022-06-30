using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("TutorialComplete") == 1)
            SceneManager.LoadScene("LevelSelection");
        else
        {
            StartCoroutine(MoveScenes());
        }   
    }

    IEnumerator MoveScenes() 
    {
        yield return new WaitForSeconds(44f);
        SceneManager.LoadScene("StartPage");
    }

}
