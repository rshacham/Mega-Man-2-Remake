using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    public GameObject bat;
    private FollowingBat follow;
    private Animator myAnimator;
    
    private void Start()
    {
        follow = GetComponentInParent<FollowingBat>();
        myAnimator = GetComponentInParent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Invoke("BatFollow", 1.2f);
    }

    private void BatFollow()
    {
        follow.FollowTrue();
        myAnimator.SetBool("Awake", true);
        
    }
}