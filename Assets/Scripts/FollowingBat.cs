using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBat : MonoBehaviour
{
    private Transform myBat;
    public Transform megaMan;
    private bool batFollow;
    [SerializeField] private float batSpeed;

    void Awake()
    {
        myBat = GetComponent<Transform>();
        batFollow = false;
    }

    // Update is called once per frame
        void Update()
        {
            if (batFollow is true)
            {
                transform.position = Vector3.MoveTowards(myBat.position, megaMan.position, batSpeed);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            batFollow = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {

            batFollow = false;
        }
}
