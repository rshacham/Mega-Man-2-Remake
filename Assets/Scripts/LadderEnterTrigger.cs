using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderEnterTrigger : MonoBehaviour

{
    private Transform triggerTransform;
    public Transform myLadder;
    private void Awake()
    {
        triggerTransform = GetComponent<Transform>();
    }

        
    private void OnTriggerEnter2D(Collider2D megaMan)
    {
        GameManager._shared.cameraDirection = true;
    }
}
