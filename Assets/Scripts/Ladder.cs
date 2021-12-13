using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public bool isLadder;
    [SerializeField] private float climbingSpeed;
    public Rigidbody2D megaMan;
    [SerializeField] private float oldGravity;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager._shared.isLadder = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameManager._shared.isLadder = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._shared.isLadder == true)
        {
            megaMan.velocity = new Vector2(0, Input.GetAxis("Vertical") * climbingSpeed);
            megaMan.gravityScale = 0;
            return;
        }

        megaMan.gravityScale = oldGravity;
    }
}
