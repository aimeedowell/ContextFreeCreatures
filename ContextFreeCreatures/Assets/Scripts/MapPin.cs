using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapPin : MonoBehaviour,  IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    GameObject cam;
    public GameObject levelUI;
    public Sprite greenPin;
    public int levelNumber;

    // Start is called before the first frame update
    void Start()
    {
         cam = GameObject.Find("Main Camera");  
         levelUI.SetActive(false);
    }

    void Update() 
    {
        SetGreenPins();
    }

    void SetGreenPins()
    {
        switch(levelNumber) 
        {
            case 1:
                if (StaticVariables.Level1Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 2:
                if (StaticVariables.Level2Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 3:
                if (StaticVariables.Level3Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 4:
                if (StaticVariables.Level4Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 5:
                if (StaticVariables.Level5Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 6:
                if (StaticVariables.Level6Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 7:
                if (StaticVariables.Level7Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 8:
                if (StaticVariables.Level8Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 9:
                if (StaticVariables.Level9Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 10:
                if (StaticVariables.Level10Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 11:
                if (StaticVariables.Level11Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 12:
                if (StaticVariables.Level12Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 13:
                if (StaticVariables.Level13Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 14:
                if (StaticVariables.Level14Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            case 15:
                if (StaticVariables.Level15Stars > 0)
                    this.GetComponent<Image>().sprite = greenPin;
                break;
            
        }
    }
    public void OnPointerEnter(PointerEventData data)
    {
        levelUI.SetActive(true);
        cam.GetComponent<LevelSelectionPage>().SetStars();
        MouseClickSoundManager.PlayHoverClick();
    }

    public void OnPointerUp(PointerEventData data)
    {
        MouseClickSoundManager.PlayClickUp();
    }

    public void OnPointerExit(PointerEventData data)
    {
        levelUI.SetActive(false);
    }

    public void OnPointerDown(PointerEventData data)
    {
        MouseClickSoundManager.PlayOnClick();

        switch (levelNumber) 
        {
            case 1:
                cam.GetComponent<SceneLoad>().ToLevel1();
                if (StaticVariables.Level1Stars == 0 && StaticVariables.CoinCount >= 100)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 100);
                break;
            case 2:
                cam.GetComponent<SceneLoad>().ToLevel2();
                if (StaticVariables.Level2Stars == 0 && StaticVariables.CoinCount >= 100)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 100);
                break;
            case 3:
                cam.GetComponent<SceneLoad>().ToLevel3();
                if (StaticVariables.Level3Stars == 0 && StaticVariables.CoinCount >= 150)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
                break;
            case 4:
                cam.GetComponent<SceneLoad>().ToLevel4();
                if (StaticVariables.Level4Stars == 0 && StaticVariables.CoinCount >= 150)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
                break;
            case 5:
                cam.GetComponent<SceneLoad>().ToLevel5();
                if (StaticVariables.Level5Stars == 0 && StaticVariables.CoinCount >= 150)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
                break;
            case 6:
                cam.GetComponent<SceneLoad>().ToLevel6();
                if (StaticVariables.Level6Stars == 0 && StaticVariables.CoinCount >= 150)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
                break;
            case 7:
                cam.GetComponent<SceneLoad>().ToLevel7();
                if (StaticVariables.Level7Stars == 0 && StaticVariables.CoinCount >= 150)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
                break;
            case 8:
                cam.GetComponent<SceneLoad>().ToLevel8();
                if (StaticVariables.Level8Stars == 0 && StaticVariables.CoinCount >= 150)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 150);
                break;
            case 9:
                cam.GetComponent<SceneLoad>().ToLevel9();
                if (StaticVariables.Level9Stars == 0 && StaticVariables.CoinCount >= 200)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
                break;   
            case 10:
                cam.GetComponent<SceneLoad>().ToLevel10();
                if (StaticVariables.Level10Stars == 0 && StaticVariables.CoinCount >= 200)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
                break;      
            case 11:
                cam.GetComponent<SceneLoad>().ToLevel11();
                if (StaticVariables.Level11Stars == 0 && StaticVariables.CoinCount >= 200)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
                break;    
            case 12:
                cam.GetComponent<SceneLoad>().ToLevel12();
                if (StaticVariables.Level12Stars == 0 && StaticVariables.CoinCount >= 200)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
                break;    
            case 13:
                cam.GetComponent<SceneLoad>().ToLevel13();
                if (StaticVariables.Level13Stars == 0 && StaticVariables.CoinCount >= 200)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
                break;    
            case 14:
                cam.GetComponent<SceneLoad>().ToLevel14();
                if (StaticVariables.Level14Stars == 0 && StaticVariables.CoinCount >= 200)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
                break;    
            case 15:
                cam.GetComponent<SceneLoad>().ToLevel15();
                if (StaticVariables.Level15Stars == 0 && StaticVariables.CoinCount >= 200)
                    PlayerPrefs.SetInt("Coins", StaticVariables.CoinCount -= 200);
                break;                                                                
        }
    }
}
