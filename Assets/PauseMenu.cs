using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject YouDead;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }

        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        Colect.theCoins = 0;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restsrt()
    {
        SceneManager.LoadScene(1);
        Colect.theCoins = 0;
        pauseMenuUI.SetActive(false);
        YouDead.SetActive(false);
        Time.timeScale = 1f;
    }

}