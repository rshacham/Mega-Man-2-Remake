using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Room Camera
    [SerializeField] private float speed;
    private Vector3 velocity = Vector3.zero;
    



    //Follow Camera
    [SerializeField] private Transform megaMan;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Room Camera(Used when i need to move to another room inside the stage, not finished)
        //transform.position = Vector3.SmoothDamp(transform.position,new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
        
        //Makes the camera follow Mega Man
        float megaManX = megaMan.position.x;
        float megaManY = megaMan.position.y;
        //if (megaManX > GameManager._shared.cameraLeftBoundary & megaManX < GameManager._shared.cameraRightBoundary) 
        ///{
        //    transform.position = new Vector3(megaMan.position.x, transform.position.y, transform.position.z);
        //}

        if (GameManager._shared.cameraDirection is false & megaManX > GameManager._shared.cameraLeftBoundary & megaManX < GameManager._shared.cameraRightBoundary)
        {
            transform.position = new Vector3(megaMan.position.x, transform.position.y, transform.position.z);
        }

        else if (GameManager._shared.cameraDirection is true)
        {
            //Room Camera(Used when i need to move to another room inside the stage, not finished)
            transform.position = Vector3.SmoothDamp(transform.position,new Vector3(GameManager._shared.cameraPosX, GameManager._shared.cameraPosY, transform.position.z), ref velocity, speed);
        }
    }


    
    public void MoveToRoom(Transform newRoom)
    {
        GameManager._shared.cameraPosX = newRoom.position.x;
        GameManager._shared.cameraPosY = newRoom.position.y;
    }
}
