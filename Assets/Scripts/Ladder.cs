using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public bool isLadder;
    [SerializeField] private float climbingSpeed;
    public Rigidbody2D megaMan;
    private float oldGravity;
    private void Start()
    {
        isLadder = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isLadder = false;
        megaMan.gravityScale = oldGravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLadder == true)
        {
            megaMan.velocity = new Vector2(0, Input.GetAxis("Vertical") * climbingSpeed);
        }
    }
}
