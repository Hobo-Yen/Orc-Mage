using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfinitGameOverScreen : MonoBehaviour
{
    public void InfinitGameOverScreenOn()
    {
        gameObject.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Infinite");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
