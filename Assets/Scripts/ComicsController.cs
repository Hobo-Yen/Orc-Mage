using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.ExceptionServices;
using System;

public class ComicsController : MonoBehaviour
{
    public float[][] rollImage = new float[2][]; 
    [SerializeField] protected Image[] comicsArray;
    protected int comicsCount;
    protected int fillAmountCount;
    [SerializeField] protected GameObject NextButton;
    [SerializeField] protected GameObject Next_SceneButton;
    void Start()
    {
        rollImage[0] = new float[3] {0.25f, 0.5f, 0.25f};
        rollImage[1] = new float[2] {0.25f, 0.75f};
        comicsCount= 0;
        fillAmountCount= 0;
       
       
    }
    public void NextStepButton()
    {
        comicsArray[comicsCount].fillAmount += rollImage[comicsCount][fillAmountCount];

        if (comicsCount == 1)
        {
            comicsArray[0].fillAmount = 0;
        }
        if (fillAmountCount == 2 && comicsCount == 0)
        {
            fillAmountCount = 0;
            comicsCount++;                        
        }
        else if (comicsCount == 1 && fillAmountCount >= 1)
        {
            NextButton.SetActive(false);
            Next_SceneButton.SetActive(true);
        }
        else
        {
            fillAmountCount++;
        } 
    }
    public void NextSceneButton()
    {
        SceneManager.LoadScene("Main");
    }
}
