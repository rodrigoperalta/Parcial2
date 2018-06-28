using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LandingZone") //Checks collision with the landing zones
        {
            if (LevelManager.Get().ReturnVVel() * 20 > -4) //If speed is too high, crushes
            {
                LevelManager.Get().AddScore();
                LevelManager.Get().LandedScreen(); //Loads landing screen
            }
            else            
                LevelManager.Get().CrushedScreen();            
        }

        if (collision.gameObject.tag == "Terrain")        //Collision with terrain = crush 
            LevelManager.Get().CrushedScreen();       

        if (collision.gameObject.tag == "CameraZoomCheck")  //when to zoom in
            CameraZoom.Get().DoZoom();
        
    }
}
