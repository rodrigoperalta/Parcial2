using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    private static CameraZoom cameraZoom;
    private Vector3 playerPos;
    public int zoom = 20; //Amount of zoom
    

    public static CameraZoom Get()
    {
        return cameraZoom;
    }

    private void Awake()
    {
        cameraZoom = this;
    }
    
    public void GetPlayerPos(Vector3 _playerPos) //Gets Player Position
    {
        playerPos.x = _playerPos.x;
        playerPos.y = _playerPos.y;
        playerPos.z = this.transform.position.z;
    }

    public void DoZoom()  //Zooms camera when close to a landing zone
    {
        this.transform.position = playerPos;
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, 1);
    }
       
       


}
