using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager pauseManager;
    public GameObject pauseMenuScreen;
    public GameObject landingMenuScreen;
    public GameObject lostMenuScreen;
    public static bool isPaused;
    public bool hasLanded;
    public bool hasCrushed;

   public static PauseManager Get()
    {
        return pauseManager;
    }

    void Start()
    {
        pauseManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if (Time.timeScale == 0)
        {
            Debug.Log("time 0");
        }
        if (Time.deltaTime == 0)
        {
            Debug.Log("dtime 0");
        }*/
        
        if (isPaused == true)
        {            
            pauseMenuScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuScreen.SetActive(false);
            Time.timeScale = 1f;
        }

        if (hasLanded)
        {
            landingMenuScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            landingMenuScreen.SetActive(false);
            Time.timeScale = 1f;
        }

        if (hasCrushed)
        {
            lostMenuScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            lostMenuScreen.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    public void Resume()
    {
        isPaused = false;
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EnterPause()
    {
        isPaused = true;        
    }

    public void ExitPause()
    {
        isPaused = false;
    }

    public void NextLevel()
    {
        LevelManager.Get().NextLevel();
    }

    public void Landed()
    {
        hasLanded = true;
    }

    public void Crushed()
    {
        hasCrushed = true;
    }
}
