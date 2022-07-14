using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public bool isBadge = false;
    public bool isFloodRetry = false; 
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
            StaticVariables.CurrentLevel = 1;
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
            StaticVariables.CurrentLevel = 2;
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
            StaticVariables.CurrentLevel = 3;
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
            StaticVariables.CurrentLevel = 4;
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
            StaticVariables.CurrentLevel = 5;
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
            StaticVariables.CurrentLevel = 6;
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

        if (isBadge && !isFloodRetry)
        {
            StartCoroutine(Level7());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);

            if (calledFromItself)
                StaticVariables.StartFlood = 1;

            SceneManager.LoadScene("Level7");
            StaticVariables.CurrentLevel = 7;
            if (StaticVariables.Level7Stars == 0 && StaticVariables.CoinCount >= 150)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
            isFloodRetry = false;

        }
    }

    public void FloodRetry()
    {
        isFloodRetry = true;
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
            StaticVariables.CurrentLevel = 8;
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
            StaticVariables.CurrentLevel = 9;
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
            StaticVariables.CurrentLevel = 10;
            if (StaticVariables.Level10Stars == 0 && StaticVariables.CoinCount >= 200)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
        }
    }
        public void ToLevel11()
    {
        PlayStartAnime("Level11");
        if (isBadge)
        {
            StartCoroutine(Level11());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level11");
            StaticVariables.CurrentLevel = 11;
            if (StaticVariables.Level11Stars == 0 && StaticVariables.CoinCount >= 200)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
        }
    }

    public void ToLevel12()
    {
        PlayStartAnime("Level12");
        if (isBadge)
        {
            StartCoroutine(Level12());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level12");
            StaticVariables.CurrentLevel = 12;
            if (StaticVariables.Level12Stars == 0 && StaticVariables.CoinCount >= 200)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
        }
    }
    
    public void ToLevel13()
    {
        PlayStartAnime("Level13");
        if (isBadge)
        {
            StartCoroutine(Level13());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level13");
            StaticVariables.CurrentLevel = 13;
            if (StaticVariables.Level13Stars == 0 && StaticVariables.CoinCount >= 200)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
        }
    }
    
    public void ToLevel14()
    {
        PlayStartAnime("Level14");
        if (isBadge)
        {
            StartCoroutine(Level14());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level14");
            StaticVariables.CurrentLevel = 14;
            if (StaticVariables.Level14Stars == 0 && StaticVariables.CoinCount >= 200)
                PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
        }
    }

    public void ToLevel15()
    {
        PlayStartAnime("Level15");
        if (isBadge)
        {
            StartCoroutine(Level15());
            isBadge = false;
        }
        else
        {
            buffer.SetActive(true);
            SceneManager.LoadScene("Level15");
            StaticVariables.CurrentLevel = 15;
            if (StaticVariables.Level15Stars == 0 && StaticVariables.CoinCount >= 200)
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
        StaticVariables.CurrentLevel = 1;
        if (StaticVariables.Level1Stars == 0 && StaticVariables.CoinCount >= 100)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 100);
    }
    IEnumerator Level2()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level2");
        StaticVariables.CurrentLevel = 2;
        if (StaticVariables.Level2Stars == 0 && StaticVariables.CoinCount >= 100)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 100);
    }

    IEnumerator Level3()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level3");
        StaticVariables.CurrentLevel = 3;
        if (StaticVariables.Level3Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level4()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level4");
        StaticVariables.CurrentLevel = 4;
        if (StaticVariables.Level4Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level5()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level5");
        StaticVariables.CurrentLevel = 5;
        if (StaticVariables.Level5Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level6()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level6");
        StaticVariables.CurrentLevel = 6;
        if (StaticVariables.Level6Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level7()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level7");
        StaticVariables.CurrentLevel = 7;
        if (StaticVariables.Level7Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level8()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level8");
        StaticVariables.CurrentLevel = 8;
        if (StaticVariables.Level8Stars == 0 && StaticVariables.CoinCount >= 150)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
    }

    IEnumerator Level9()
    {
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene("Level9");
        StaticVariables.CurrentLevel = 9;
        if (StaticVariables.Level9Stars == 0 && StaticVariables.CoinCount >= 200)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
    }
    IEnumerator Level10()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level10");
        StaticVariables.CurrentLevel = 10;
        if (StaticVariables.Level10Stars == 0 && StaticVariables.CoinCount >= 200)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
    }
    IEnumerator Level11()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level11");
        StaticVariables.CurrentLevel = 11;
        if (StaticVariables.Level11Stars == 0 && StaticVariables.CoinCount >= 200)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
    }
    IEnumerator Level12()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level12");
        StaticVariables.CurrentLevel = 12;
        if (StaticVariables.Level12Stars == 0 && StaticVariables.CoinCount >= 200)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
    }
    IEnumerator Level13()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level12");
        StaticVariables.CurrentLevel = 13;
        if (StaticVariables.Level13Stars == 0 && StaticVariables.CoinCount >= 200)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
    }
    IEnumerator Level14()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level14");
        StaticVariables.CurrentLevel = 14;
        if (StaticVariables.Level14Stars == 0 && StaticVariables.CoinCount >= 200)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
    }
    IEnumerator Level15()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level15");
        StaticVariables.CurrentLevel = 15;
        if (StaticVariables.Level15Stars == 0 && StaticVariables.CoinCount >= 200)
            PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
    }

    IEnumerator LevelSelect(float secs)
    {
        yield return new WaitForSeconds(secs);
        if (PlayerPrefs.GetInt("TutorialComplete") == 1)
            SceneManager.LoadScene("LevelSelection");
    }

    public void AreYouSurePlayerPrefs()
    {
        this.gameObject.GetComponent<LevelSelectionPage>().areYouSure.SetActive(true);
    }

    public void ExitAreYouSurePlayerPrefs()
    {
        this.gameObject.GetComponent<LevelSelectionPage>().areYouSure.SetActive(false);
    }

    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("StartPage");
    }
} 
