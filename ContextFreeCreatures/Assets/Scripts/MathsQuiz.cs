using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathsQuiz : MonoBehaviour
{
    public GameObject confetti;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void OnThomasClick()
    {
        this.gameObject.SetActive(true);
    }

    public void OnCorrectClick()
    {
        // animation confetti
        confetti.GetComponent<Animator>().enabled = true;
        confetti.GetComponent<Animator>().Play(0);
        confetti.GetComponent<AudioSource>().Play(0);
        StartCoroutine(ClosePopUp());
    }

    public IEnumerator ClosePopUp()
    {
        yield return new WaitForSeconds(1.2f);

        this.gameObject.SetActive(false);
    }
} 
