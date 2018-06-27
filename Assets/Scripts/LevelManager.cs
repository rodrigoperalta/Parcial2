using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    private int score;
    public int fuel;  
    private float time;
    private float altitude;
    private float hVel;
    private float vVel;


    public static LevelManager Get()
    {
        return levelManager;
    }

    void Start()
    {
        PauseManager.Get().ExitPause();
        //Time.timeScale = 1f;               
    }

    private void Awake()
    {
        MakeThisTheOnlyGameManager();
        fuel = 5000;
    }    

    void Update()
    {
        AddTime();
        HUDManager.Get().GetFuel(fuel);
        HUDManager.Get().GetHVel(hVel);
        HUDManager.Get().GetVVel(vVel);
        HUDManager.Get().GetAltitude(altitude);
        HUDManager.Get().GetScore(score);
        HUDManager.Get().GetTime(time);
    }

    public void Kill()
    {
        Destroy(this);
    }

    public void AddTime()
    {
        time = time + 1 * Time.deltaTime;
    }

    public void GetHVel(float _hVel)
    {
        hVel = _hVel;
    }

    public void GetAltitude(float _alt)
    {

        altitude = _alt;
    }

    public void GetVVel(float _vVel)
    {
        vVel = _vVel;
    }

    public float ReturnVVel()
    {
        return vVel;
    }

    public float ReturnHVel()
    {
        return hVel;
    }

    public void LoseFuel()
    {
        fuel--;        
    }

    
    public void LandedScreen()
    {
        PauseManager.Get().Landed();
    }

    public void CrushedScreen()
    {
        PauseManager.Get().Crushed();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void AddScore()
    {
        score = score + 100;
        HUDManager.Get().GetScore(score);
    }

    void MakeThisTheOnlyGameManager()
    {
        if (levelManager == null)
        {
            DontDestroyOnLoad(gameObject);
            levelManager = this;
        }
        else
        {
            if (levelManager != this)
            {
                Destroy(gameObject);
            }
        }


    }
}
