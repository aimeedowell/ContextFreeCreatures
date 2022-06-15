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
        SceneManager.LoadScene("Tutorial");
    }


    public void ToLevelSelector()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void ToLevel1()
    {
        SceneManager.LoadScene("Level1");
        StaticVariables.Level = 1;
    }

    public void ToLevel2()
    {
        // SceneManager.LoadScene("Level2");
        StaticVariables.Level = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
