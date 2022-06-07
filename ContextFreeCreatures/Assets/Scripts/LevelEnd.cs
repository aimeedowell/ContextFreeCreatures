using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public GameObject starL;
    public GameObject starM;
    public GameObject starR;
    public GameObject sucessPopUp;
    public GameObject popUp;

    // Start is called before the first frame update
    void Start()
    {
        // anim = gameObject.GetComponent<Animation>();
        popUp.SetActive(false);
        sucessPopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelSuccess(int noOfStars)
    {
        
        popUp.SetActive(true);
        sucessPopUp.SetActive(true);
        starL.SetActive(true);
        starL.GetComponent<Animator>().Play("StarLeft");
        if (noOfStars > 1)
        {
            
            StartCoroutine(PlaySuccessorStar(noOfStars));
        }

    }

    private IEnumerator PlaySuccessorStar(int noOfStars)
    {
        yield return new WaitForSeconds(0.5f);

        starM.SetActive(true);
        starM.GetComponent<Animator>().Play("StarMid");
        
        if (noOfStars == 3)
        {            
            StartCoroutine(PlayFinalStar());
        }
    }

    private IEnumerator PlayFinalStar()
    {
        yield return new WaitForSeconds(0.5f);
        starR.SetActive(true);
        starR.GetComponent<Animator>().Play("StarRight");
    }

}
