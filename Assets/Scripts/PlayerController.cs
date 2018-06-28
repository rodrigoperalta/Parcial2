using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody2D rig;
    public float thrust = 3.0f;
    public float rotationSpeed = 1.0f;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();        
    }
        
    void Update()
    {
        
        LevelManager.Get().GetVVel(rig.velocity.y);
        LevelManager.Get().GetHVel(rig.velocity.x);        
        LevelManager.Get().GetAltitude(this.transform.position.y);
        CameraZoom.Get().GetPlayerPos(this.transform.position);
        //Player movement and conditions when to move
        if (PauseManager.Get().GetPause() == true || PauseManager.Get().GetHasLanded() == true || PauseManager.Get().GetHasCrushed() == true || ScreenLevel.Get().GetOnLoadingScreen() == true)        
            rig.simulated = false;       
        else
        {
            rig.simulated = true;
            if (Input.GetKey(KeyCode.Space))
            {
                rig.AddForce(transform.up * thrust * Time.deltaTime);
                if (Time.timeScale == 1)
                    LevelManager.Get().LoseFuel();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //Players collisions
    {
        if (collision.gameObject.tag == "LandingZone")        
            LevelManager.Get().CrushedScreen();        

        if (collision.gameObject.tag == "Terrain")        
            LevelManager.Get().CrushedScreen();        

        if (collision.gameObject.tag == "CameraZoomCheck")
        {
            CameraZoom.Get().DoZoom();
            Destroy(collision);
        }
    }




}
