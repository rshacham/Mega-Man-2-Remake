using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Room Camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow Camera
    [SerializeField] private Transform megaMan;
    
    // Update is called once per frame
    void Update()
    {
        //Room Camera(Used when i need to move to another room inside the stage, not finished)
        //transform.position = Vector3.SmoothDamp(transform.position,new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
        
        //Makes the camera follow Mega Man
        transform.position = new Vector3(megaMan.position.x, transform.position.y, transform.position.z);
    }

    public void MoveToRoom(Transform newRoom)
    {
        currentPosX = newRoom.position.x;
    }
}
