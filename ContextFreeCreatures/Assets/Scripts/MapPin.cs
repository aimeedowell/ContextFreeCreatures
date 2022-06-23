using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapPin : MonoBehaviour,  IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
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

        }
    }
    public void OnPointerEnter(PointerEventData data)
    {
        levelUI.SetActive(true);
        cam.GetComponent<LevelSelectionPage>().SetStars();
        // Debug.Log("Mouse Over");
    }

    public void OnPointerExit(PointerEventData data)
    {
        levelUI.SetActive(false);
        // Debug.Log("Mouse Off");
    }

    public void OnPointerDown(PointerEventData data)
    {
        switch (levelNumber) 
        {
            case 1:
                cam.GetComponent<SceneLoad>().ToLevel1();
                break;
            case 2:
                cam.GetComponent<SceneLoad>().ToLevel2();
                break;
            case 3:
                cam.GetComponent<SceneLoad>().ToLevel3();
                break;
            case 4:
                cam.GetComponent<SceneLoad>().ToLevel4();
                break;
            case 5:
                cam.GetComponent<SceneLoad>().ToLevel5();
                break;
            case 6:
                cam.GetComponent<SceneLoad>().ToLevel6();
                break;
            case 7:
                cam.GetComponent<SceneLoad>().ToLevel7();
                break;
            case 8:
                cam.GetComponent<SceneLoad>().ToLevel8();
                break;
            case 9:
                cam.GetComponent<SceneLoad>().ToLevel9();
                break;   
            case 10:
                cam.GetComponent<SceneLoad>().ToLevel10();
                break;                 
        }
        // Debug.Log("Mouse Down");
    }
}
