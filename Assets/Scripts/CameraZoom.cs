using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    private static CameraZoom cameraZoom;
    public int zoom = 20;
    private Vector3 playerPos;

    public static CameraZoom Get()
    {
        return cameraZoom;
    }

    private void Awake()
    {
        cameraZoom = this;
    }

    
    public void GetPlayerPos(Vector3 _playerPos)
    {
        playerPos.x = _playerPos.x;
        playerPos.y = _playerPos.y;
        playerPos.z = this.transform.position.z;
    }

    public void DoZoom()
    {
        this.transform.position = playerPos;
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, 1);
    }
       
       


}
