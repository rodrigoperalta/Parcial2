using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenLevel : MonoBehaviour {

    public static ScreenLevel screenLevel;
    public GameObject levelScreen;
    private int level;
    public Text levelT;
    public bool onLoadingScreen;

    public static ScreenLevel Get()
    {
        return screenLevel;
    }

    void Awake()
    {
        screenLevel = this;
        onLoadingScreen = false;
    }

    public void InLoadingScreen()
    {
        levelT.text = "Level " + level;
        levelScreen.SetActive(true);
    }

    public void OffLoadingScreen()
    {
        levelScreen.SetActive(false);
    }

    public void GetLevelNumber(int _level)
    {
        level = _level;
    }

    public void LoadingScreenOnOff()
    {
        onLoadingScreen = !onLoadingScreen;
    }

    public bool GetOnLoadingScreen()
    {
        return onLoadingScreen;
    }

}
