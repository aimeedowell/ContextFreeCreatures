using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToTutorialLevel()
    {
        if (PlayerPrefs.GetInt("TutorialComplete") == 0)
            SceneManager.LoadScene("Tutorial");
    }


    public void ToLevelSelector()
    {
        if (PlayerPrefs.GetInt("TutorialComplete") == 1)
            SceneManager.LoadScene("LevelSelection");
    }

    public void ToLevel1()
    {
        SceneManager.LoadScene("Level1");
        StaticVariables.Level = 1;
    }

    public void ToLevel2()
    {
        SceneManager.LoadScene("Level2");
        StaticVariables.Level = 2;
    }

    public void ToLevel3()
    {
        // SceneManager.LoadScene("Level3");
        StaticVariables.Level = 3;
    }

    public void ToLevel4()
    {
        // SceneManager.LoadScene("Level4");
        StaticVariables.Level = 4;
    }

    public void ToLevel5()
    {
        // SceneManager.LoadScene("Level5");
        StaticVariables.Level = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
