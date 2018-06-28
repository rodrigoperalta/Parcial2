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
    public Text scoreT2;
    public Text highScoreT;
    public Text highScoreT2;
    public static bool  isPaused;
    public bool hasLanded;
    public bool hasCrushed;    
    public int highScore;

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
            pauseMenuScreen.SetActive(true);
        
        else        
            pauseMenuScreen.SetActive(false);        

        if (hasLanded)
        {
            scoreT.text = "Score: " + LevelManager.Get().ReturnScore();
            highScoreT.text = "HighScore: " + LevelManager.Get().ReturnHighScore();
            landingMenuScreen.SetActive(true);                        
        }
        else       
            landingMenuScreen.SetActive(false);       

        if (hasCrushed)
        {
            scoreT2.text = "Score: " + LevelManager.Get().ReturnScore();
            highScoreT2.text = "HighScore: " + LevelManager.Get().ReturnHighScore();
            lostMenuScreen.SetActive(true);
                        
        }
        else        
            lostMenuScreen.SetActive(false);        
    }

    public void QuitToMainMenu() //Loads Main Menu
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel() //Loads loading screen
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

    public void EnterPause() //Pauses
    {
        isPaused = true;
    }

    public void ExitPause() //Unpauses
    {
        isPaused = false;
    }    

    public void Landed() //Player has landed
    {
        hasLanded = true;
    }

    public void TurnOffLanded() //Turns off landing variable
    {
        hasLanded = false;
    }

    public void Crushed() //Player has crushed
    {
        hasCrushed = true;
    }

   

   
}
