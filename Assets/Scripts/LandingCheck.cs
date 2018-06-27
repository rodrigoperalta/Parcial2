using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LandingZone")
        {
            if (LevelManager.Get().ReturnVVel() * 20 > -4)
            {
                LevelManager.Get().AddScore();
                LevelManager.Get().LandedScreen();
            }
            else
            {
                LevelManager.Get().CrushedScreen();
            }
        }

        if (collision.gameObject.tag == "Terrain")
        {
            LevelManager.Get().CrushedScreen();            
        }

        if (collision.gameObject.tag == "CameraZoomCheck")
        {
            CameraZoom.Get().DoZoom();
        }
    }
}
