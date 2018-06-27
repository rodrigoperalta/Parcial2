using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void StartGame()
    {
        if (LevelManager.Get() != null)
        {
            LevelManager.Get().Kill();
        }
        
        SceneManager.LoadScene("Game");        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
