using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D megaMan;
    private BoxCollider2D boxCollider;
    private bool doJump;
    private float oldGravity;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        megaMan = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._shared.isLadder == false)
        {
            megaMan.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, megaMan.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) & isGrounded())
        {
            MegaJump();
        }

        if (GameManager._shared.isLadder == true)
        {
            megaMan.velocity = new Vector2(0, Input.GetAxis("Vertical") * Speed / 1.5f);
        }


    }
    private void MegaJump()
    {
        megaMan.velocity = new Vector2(megaMan.velocity.x, Speed * 1.8f);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        // if Mega Man is not touching the ground, return false
        return raycastHit2D.collider != null;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ladder")
        {
            onLadder(collider);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Ladder")
        {
            exitLadder();
        }
    }

    public void onLadder(Collider2D myLadder)
    {
        //Called when entering a ladder trigger
        megaMan.transform.position = new Vector3(myLadder.GetComponent<Transform>().position.x,
            megaMan.transform.position.y, megaMan.transform.position.z);
        GameManager._shared.isLadder = true;
        oldGravity = megaMan.gravityScale;
        megaMan.gravityScale = 0;
    }

    public void exitLadder()
    {
        //Called when exiting a ladder trigger
        GameManager._shared.isLadder = false;
        megaMan.gravityScale = oldGravity;
    }

    private void FixedUpdate()
    {
        
    }
}
