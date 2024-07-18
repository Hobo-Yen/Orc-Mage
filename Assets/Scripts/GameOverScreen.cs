using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
  
    public void GameOverScreenOn()
    {
        gameObject.SetActive(true); 
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
