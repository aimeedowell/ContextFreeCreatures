using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public bool isBadge = false;
    public GameObject buffer;

    private void Start() 
    {
        buffer.SetActive(false);
    }

    public void ToTutorialLevel()
    {
        if (PlayerPrefs.GetInt("TutorialComplete") == 0)
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Tutorial");
        }
    }


    public void ToLevelSelector()
    {
        if (isBadge)
        {
            StartCoroutine(LevelSelect(2f));
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            StartCoroutine(LevelSelect(0.5f));
        }
    }

    public void ToLevel1()
    {
        PlayStartAnime("Level1");

        if (isBadge)
        {
            StartCoroutine(Level1());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level1");
            StaticVariables.Level = 1;
            if (StaticVariables.Level1Stars == 0 && StaticVariables.CoinCount >= 100)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 100);
        }
    }

    public void ToLevel2()
    {
        PlayStartAnime("Level2");
        if (isBadge)
        {
            StartCoroutine(Level2());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level2");
            StaticVariables.Level = 2;
            if (StaticVariables.Level2Stars == 0 && StaticVariables.CoinCount >= 100)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 100);
        }
    }

    public void ToLevel3()
    {
        PlayStartAnime("Level3");
        if (isBadge)
        {
            StartCoroutine(Level3());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level3");
            StaticVariables.Level = 3;
            if (StaticVariables.Level3Stars == 0 && StaticVariables.CoinCount >= 150)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
        }
    }

    public void ToLevel4()
    {
        PlayStartAnime("Level4");
        if (isBadge)
        {
            StartCoroutine(Level4());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level4");
            StaticVariables.Level = 4;
            if (StaticVariables.Level4Stars == 0 && StaticVariables.CoinCount >= 150)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
        }
    }

    public void ToLevel5()
    {
        PlayStartAnime("Level5");
        if (isBadge)
        {
            StartCoroutine(Level5());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level5");
            StaticVariables.Level = 5;
            if (StaticVariables.Level5Stars == 0 && StaticVariables.CoinCount >= 150)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);            
        }
    }

    public void ToLevel6()
    {
        PlayStartAnime("Level6");
        if (isBadge)
        {
            StartCoroutine(Level6());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level6");
            StaticVariables.Level = 6;
            if (StaticVariables.Level6Stars == 0 && StaticVariables.CoinCount >= 150)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
        }
    }

    public void ToLevel7()
    {
        PlayStartAnime("Level7");
        Scene scene = SceneManager.GetActiveScene();
        bool calledFromItself = false;
        if (scene.name == "Level7")
            calledFromItself = true;

        if (isBadge)
        {
            StartCoroutine(Level7());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level7");
            StaticVariables.Level = 7;
            if (StaticVariables.Level7Stars == 0 && StaticVariables.CoinCount >= 150)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);

            if (calledFromItself)
                StaticVariables.StartFlood = 1;
        }
    }

    public void ToLevel8()
    {
        PlayStartAnime("Level8");
        if (isBadge)
        {
            StartCoroutine(Level8());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level8"); 
            StaticVariables.Level = 8;
            if (StaticVariables.Level8Stars == 0 && StaticVariables.CoinCount >= 150)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
        }
    }

    public void ToLevel9()
    {
        PlayStartAnime("Level9");
        if (isBadge)
        {
            StartCoroutine(Level9());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level9");
            StaticVariables.Level = 9;
            if (StaticVariables.Level9Stars == 0 && StaticVariables.CoinCount >= 200)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
        }
    }

    public void ToLevel10()
    {
        PlayStartAnime("Level10");
        if (isBadge)
        {
            StartCoroutine(Level10());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level10");
            StaticVariables.Level = 10;
            if (StaticVariables.Level10Stars == 0 && StaticVariables.CoinCount >= 200)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
        }
    }
    public void QuitGame()
    {
        DataToCSV.GameQuit();
        Application.Quit();
    }

    public void ShowBadge()
    {
        if (isBadge)
        {
            this.gameObject.GetComponent<BadgeUnlock>().ShowBadge();
        }
    }

    void PlayStartAnime(string levelName)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != levelName)
            StaticVariables.ShouldPlayStartAnime = 1;
    }
    

    IEnumerator Level1()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level1");
        StaticVariables.Level = 1;
        if (StaticVariables.Level1Stars == 0 && StaticVariables.CoinCount >= 100)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 100);
    }
    IEnumerator Level2()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level2");
        StaticVariables.Level = 2;
        if (StaticVariables.Level2Stars == 0 && StaticVariables.CoinCount >= 100)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 100);
    }

    IEnumerator Level3()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level3");
        StaticVariables.Level = 3;
        if (StaticVariables.Level3Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level4()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level4");
        StaticVariables.Level = 4;
        if (StaticVariables.Level4Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level5()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level5");
        StaticVariables.Level = 5;
        if (StaticVariables.Level5Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level6()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level6");
        StaticVariables.Level = 6;
        if (StaticVariables.Level6Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level7()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level7");
        StaticVariables.Level = 7;
        if (StaticVariables.Level7Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level8()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level8");
        StaticVariables.Level = 8;
        if (StaticVariables.Level8Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level9()
    {
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene("Level9");
        StaticVariables.Level = 9;
        if (StaticVariables.Level9Stars == 0 && StaticVariables.CoinCount >= 200)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
    }
    IEnumerator Level10()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level10");
        StaticVariables.Level = 10;
        if (StaticVariables.Level10Stars == 0 && StaticVariables.CoinCount >= 200)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
    }

    IEnumerator LevelSelect(float secs)
    {
        yield return new WaitForSeconds(secs);
        if (PlayerPrefs.GetInt("TutorialComplete") == 1)
            SceneManager.LoadScene("LevelSelection");
    }
} 
