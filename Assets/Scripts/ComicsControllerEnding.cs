using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ComicsControllerEnding : MonoBehaviour
{
    public float[] rollImage = { 0.25f, 0.25f, 0.25f, 0.25f};
    protected int comicsCount;
    protected int fillAmountCount;
    [SerializeField] protected GameObject nextButton;
    [SerializeField] protected GameObject fin_SceneButton;
    [SerializeField] protected Image thirdComics;
    [SerializeField] protected GameObject afterwordScreen;
    void Start()
    {      
        comicsCount = 0;
        fillAmountCount = 0;
    }
    public void NextStepButton()
    {
        thirdComics.fillAmount += rollImage[fillAmountCount];
                
        if (comicsCount == 0 && fillAmountCount >= 3)
        {
            comicsCount++;
        }
        else if (comicsCount == 1 && fillAmountCount >= 3)
        {
            nextButton.SetActive(false);
            afterwordScreen.SetActive(true);
            fin_SceneButton.SetActive(true);
        }
        else
        {
            fillAmountCount++;
        }
    }
    public void FinSceneButton()
    {
        SceneManager.LoadScene("StartScreen");
    }

}

