using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #if DEVELOPMENT_BUILD
            PlayerPrefs.DeleteAll(); // DELETE BEFORE BUILDING FOR REAL 
         #endif

        if (PlayerPrefs.GetInt("TutorialComplete") == 1)
            SceneManager.LoadScene("LevelSelection");
        else
        {
            StaticVariables.NoOfLives = 5;
            StartCoroutine(MoveScenes());
        }

        
    }

    IEnumerator MoveScenes() 
    {
        yield return new WaitForSeconds(44f);
        SceneManager.LoadScene("StartPage");
    }

}
