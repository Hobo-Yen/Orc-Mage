using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YouWonScript : MonoBehaviour
{
    public void YouWonScreenOn()
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
    public void ContinueButton () 
    {
        SceneManager.LoadScene("Ending");
    }
}
    
