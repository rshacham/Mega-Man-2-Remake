using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBat : MonoBehaviour
{
    [SerializeField] private GameObject batObject;
    private Transform myBat;
    [SerializeField]public int batLife;
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
            
            if (batLife == 0)
            {
                batObject.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D trigger)
        {
            if (trigger.CompareTag("BasicShots"))
            {
                batLife -= 1;
                GameManager._shared.PlaySound("enemyHit");
            }

            if (trigger.CompareTag("MegaMan"))
            {
                GameManager._shared.TakeDamage(2);
            }
        }
        public void FollowTrue()
        {
            batFollow = true;
        }

        public void FollowFalse()
        {
            batFollow = false;
        }
}
