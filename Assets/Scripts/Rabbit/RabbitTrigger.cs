using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitTrigger : MonoBehaviour
{
    public Rabbit rabbitScript;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!rabbitScript.Jump)
        {
            rabbitScript.Jump = true;
            rabbitScript.ZeroAngle();
        }

    }
}
