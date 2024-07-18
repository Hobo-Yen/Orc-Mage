using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class StartMenuScript : MonoBehaviour
{
    [SerializeField] protected GameObject helpPanel; 
    public void HelpButton()
    {
        if (helpPanel.activeSelf == false)
        {
            helpPanel.SetActive(true);
        }
        else
        {
            helpPanel.SetActive(false);
        }
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Opening");
    }
    public void EndlessGameStartButton()
    {
        SceneManager.LoadScene("Infinite");
    }
    public void Exit()
    {
       Application.Quit();
    }
}
