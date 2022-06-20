using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public bool isBadge = false;
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
        if (isBadge)
        {
            StartCoroutine(LevelSelect());
            isBadge = false;
        }
        else
        {
            if (PlayerPrefs.GetInt("TutorialComplete") == 1)
                SceneManager.LoadScene("LevelSelection");
        }
    }

    public void ToLevel1()
    {
        if (isBadge)
        {
            StartCoroutine(Level1());
            isBadge = false;
        }
        else
        {
            SceneManager.LoadScene("Level1");
            StaticVariables.Level = 1;
        }
    }

    public void ToLevel2()
    {
        if (isBadge)
        {
            StartCoroutine(Level2());
            isBadge = false;
        }
        else
        {
            SceneManager.LoadScene("Level2");
            StaticVariables.Level = 2;
        }
    }

    public void ToLevel3()
    {
        if (isBadge)
        {
            StartCoroutine(Level3());
            isBadge = false;
        }
        else
        {
            SceneManager.LoadScene("Level3");
            StaticVariables.Level = 3;
        }
    }

    public void ToLevel4()
    {
        if (isBadge)
        {
            StartCoroutine(Level4());
            isBadge = false;
        }
        else
        {
            SceneManager.LoadScene("Level4");
            StaticVariables.Level = 4;
        }
    }

    public void ToLevel5()
    {
        if (isBadge)
        {
            StartCoroutine(Level5());
            isBadge = false;
        }
        else
        {
            SceneManager.LoadScene("Level5");
            StaticVariables.Level = 5;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowBadge()
    {
        if (isBadge)
        {
            this.gameObject.GetComponent<BadgeUnlock>().ShowBadge();
        }
    }
    

    IEnumerator Level1()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level1");
        StaticVariables.Level = 1;
    }
    IEnumerator Level2()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level2");
        StaticVariables.Level = 2;
    }

    IEnumerator Level3()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level3");
        StaticVariables.Level = 3;
    }

    IEnumerator Level4()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level4");
        StaticVariables.Level = 4;
    }

    IEnumerator Level5()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level5");
        StaticVariables.Level = 5;
    }

    IEnumerator LevelSelect()
    {
        yield return new WaitForSeconds(2f);
        if (PlayerPrefs.GetInt("TutorialComplete") == 1)
            SceneManager.LoadScene("LevelSelection");
    }
} 
