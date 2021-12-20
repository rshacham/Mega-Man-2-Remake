using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderEnd : MonoBehaviour
{
    public Rigidbody2D megaManRigid;
    public Animator megaAnimator;
    public GameObject myGround;
    public GameObject myTrigger;
    [SerializeField] private Vector3 newPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        megaAnimator.SetBool("AfterLadder", true);
        GameManager._shared.isLadder = true;
        Movement.canMove = false;
        Movement.megaPosition = newPosition;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        print("hey");
        megaManRigid.velocity = new Vector2(0, 0);
        megaAnimator.SetBool("OnLadder", false);
        myGround.SetActive(true);
        myTrigger.SetActive(false);
        Movement.canMove = true;
    }
}
