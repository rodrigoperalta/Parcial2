using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static PauseManager pauseManager;
    public GameObject pauseMenuScreen;
    public GameObject landingMenuScreen;
    public GameObject lostMenuScreen;
    public Text scoreT;
    public static bool  isPaused;
    public bool hasLanded;
    public bool hasCrushed;
    public int score;

    public static PauseManager Get()
    {
        return pauseManager;
    }

    void Awake()
    {
        pauseManager = this;
    }
        
    void Update()
    {
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
            scoreT.text = "Score: " + LevelManager.Get().ReturnScore();
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
            scoreT.text = "Score: " + LevelManager.Get().ReturnScore();
            lostMenuScreen.SetActive(true);
            Time.timeScale = 0f;            
        }
        else
        {
            lostMenuScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        LevelManager.Get().NextLevel();
    }

    public bool GetPause()
    {
        return isPaused;
    }    

    public bool GetHasLanded()
    {
        return hasLanded;
    }

    public bool GetHasCrushed()
    {
        return hasCrushed;
    }    

    public void EnterPause()
    {
        isPaused = true;
    }

    public void ExitPause()
    {
        isPaused = false;
    }    

    public void Landed()
    {
        hasLanded = true;
    }

    public void TurnOffLanded()
    {
        hasLanded = false;
    }

    public void Crushed()
    {
        hasCrushed = true;
    }

   
}
