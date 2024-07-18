using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool paused;
    public GameObject pauseMenu;
    public GameObject gameOverSkrin;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !gameOverSkrin.activeSelf)
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    public void ResumeButton()
    {
        Resume();
    }
    public void ExitButton()
    {
        Resume();
        SceneManager.LoadScene("StartScreen");
    }
    void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        paused= false;
    }
    void Pause() 
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        paused= true;
    }
}
