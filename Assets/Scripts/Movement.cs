using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject[] grounds;
    [SerializeField] private float Speed; 
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D megaMan;
    private BoxCollider2D boxCollider;
   // private bool doJump;
    private float oldGravity;
    private SpriteRenderer myRenderer;
    private Animator myAnimator;
    private int groundCounter = 0;
    public static Vector3 megaPosition;
    private Vector3 smoothVelocity = Vector3.zero; //ref velocity for SmoothDamp movement


    [SerializeField] public static bool canMove; //if false, mega man wouldn't be able to move without animation


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        megaMan = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        canMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._shared.isLadder == false & canMove)
        {
            megaMan.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, megaMan.velocity.y);
            if (megaMan.velocity.x < 0f)
            {
                myRenderer.flipX = false; 
            }

            if (megaMan.velocity.x > 0f)
            {
                myRenderer.flipX = true;
            }

            if (Mathf.Abs(megaMan.velocity.x) > 0)
            {
                myAnimator.SetBool("Run", true);
            }

            else
            {
                myAnimator.SetBool("Run", false);
            }

            myAnimator.SetFloat("Fall", megaMan.velocity.y);
        }

        if (isGrounded())
        {
            if (Input.GetKey(KeyCode.Space))
            {
                MegaJump();
            }

            else
            {
                myAnimator.SetBool("Jump", false);
            }

        }
        

        if (GameManager._shared.isLadder == true & canMove)
        {
            megaMan.velocity = new Vector2(0, Input.GetAxis("Vertical") * Speed / 1.5f);
            if (Mathf.Abs(megaMan.velocity.y) > 0)
            {
                myAnimator.SetBool("Climb", true);
            }

            else
            {
                myAnimator.SetBool("Climb", false);
            }
        }

        if (!canMove)
        {
            transform.position = Vector3.SmoothDamp(transform.position, megaPosition, ref smoothVelocity, 3f);
        }


    }
        
    private void MegaJump()
    {
        megaMan.velocity = new Vector2(megaMan.velocity.x, Speed * 1.8f);
        myAnimator.SetBool("Jump", true);
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
        myAnimator.SetBool("OnLadder", true);
    }

    public void exitLadder()
    {
        //Called when exiting a ladder trigger
        GameManager._shared.isLadder = false;
        megaMan.gravityScale = oldGravity;
        myAnimator.SetBool("OnLadder", false);
    }

    public void createGround()
    {
        grounds[groundCounter].SetActive(true);
        groundCounter += 1;
    }



    private void FixedUpdate()
    {
        
    }
}
