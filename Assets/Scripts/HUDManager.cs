using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    private static HUDManager hUDManager;
    private float time;
    private int altitude;
    private int hVel;
    private int vVel;
    private int score;
    public Text scoreT;
    public Text fuelT;
    public Text timeT;
    public Text altitudeT;
    public Text hVelT;
    public Text vVelT;
    public int displayMultiplier;

    public static HUDManager Get()
    {
        return hUDManager;
    }
    // Use this for initialization
    void Start () {
        scoreT.text = "Score: " + score.ToString();
        fuelT.text = "Fuel: " + 100.ToString();
        timeT.text = "Time: " + time.ToString();
        hVelT.text = "Horizontal Velocity: " + hVel.ToString();
        altitudeT.text = "Altitude: " + altitude.ToString();
        vVelT.text = "Vertical Velocity: " + vVel.ToString();
        displayMultiplier = 20;
    }

    private void Awake()
    {
        hUDManager = this;
    }   

    // Update is called once per frame
    void Update () {
        altitudeT.text = "Altitude: " + altitude.ToString();
        hVelT.text = "Horizontal Velocity: " + hVel.ToString();
        vVelT.text = "Vertical Velocity: " + vVel.ToString();
        scoreT.text = "Score: " + score.ToString();
        timeT.text = "Time: " + time.ToString();       
    }

    public void GetHVel(float _hVel)
    {        
        hVel = (int)(_hVel * displayMultiplier);
    }

    public void GetAltitude(float _alt)
    {
        
        altitude = (int)(_alt * displayMultiplier);
    }

    public void GetVVel(float _vVel)
    {
        vVel = (int)(_vVel * displayMultiplier);
    }
    

    public void GetFuel(int _fuel)
    {        
        fuelT.text = "Fuel: " + _fuel.ToString();
    }

    public void GetScore(int _score)
    {
        score = _score;
    }

    public void GetTime(float _time)
    {
        time = (int)_time;
    }
}
