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
    private float hVel; //Horizontal Velocity
    private float vVel; //Vertical Velocity
    private int level;


    public static LevelManager Get()
    {
        return levelManager;
    }

    void Start()
    {
        PauseManager.Get().ExitPause();                     
    }

    private void Awake()
    {
        level = 1;
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
        Lose();
    }

    public void Lose() //Lose condition because of fuel
    {
        if (fuel <= 0)
            PauseManager.Get().Crushed();
    }
    public void Kill()
    {
        Destroy(this);
    }

    public void AddTime() //If not paused, adds time
    {
        if (PauseManager.Get().GetPause() == false && PauseManager.Get().GetHasLanded() == false && PauseManager.Get().GetHasCrushed() == false)        
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

    public void LandedScreen() //Plays landed screen
    {
        PauseManager.Get().Landed();
    }

    public void CrushedScreen() //Plays crushed screen
    {
        PauseManager.Get().Crushed();
    }

    public void NextLevel() //Sets up loading screen
    {
        level++;
        ScreenLevel.Get().LoadingScreenOnOff();
        ScreenLevel.Get().GetLevelNumber(level);
        ScreenLevel.Get().InLoadingScreen();
        PauseManager.Get().TurnOffLanded();
        StartCoroutine(LoadLevelAfterTime(3));
    }

    IEnumerator LoadLevelAfterTime(float time) // Time to wait between loading screen and next level
    {       
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Game");
        ScreenLevel.Get().LoadingScreenOnOff();
    }

    public void AddScore() //Adds score and lets HUD know
    {
        score = score + 100;
        HUDManager.Get().GetScore(score);
    }

    public int ReturnScore()
    {
        return score;
    }

    void MakeThisTheOnlyGameManager() //Singleton
    {
        if (levelManager == null)
        {
            DontDestroyOnLoad(gameObject);
            levelManager = this;
        }
        else
        {
            if (levelManager != this)           
                Destroy(gameObject);            
        }
    }
}
