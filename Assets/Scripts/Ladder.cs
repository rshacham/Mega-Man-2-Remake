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
    [SerializeField] private GameObject ground;
    public Animator megaAnimator;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager._shared.isLadder = true;
        megaAnimator.SetBool("AfterLadder", false);
        ground.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "MegaMan")
        {            
            ground.SetActive(true);
        }

        GameManager._shared.isLadder = false;
        megaAnimator.SetBool("AfterLadder", true);


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
