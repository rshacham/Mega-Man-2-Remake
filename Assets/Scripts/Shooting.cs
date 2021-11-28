using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float shootingCooldown;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject[] shots;
    private float cooldownTimer = 10000;
    private Rigidbody2D megaMan;
    private Transform myShooter;
    private float direction;
    // Start is called before the first frame update

    private void Awake()
    {
        direction = 1;
        megaMan = GetComponentInParent<Rigidbody2D>();
        myShooter = GetComponent<Transform>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X) && cooldownTimer > shootingCooldown)
        {
            BasicShoot();
        }
        cooldownTimer += Time.deltaTime;

        if (megaMan.velocity.x < 0 & direction != -1)
        {
            myShooter.position = new Vector3(myShooter.position.x - 2, myShooter.position.y, myShooter.position.z);
            direction = -1;
        }

        if (megaMan.velocity.x > 0 & direction != 1)
        {
            myShooter.position = new Vector3(myShooter.position.x + 2, myShooter.position.y, myShooter.position.z);
            direction = 1;
        }
    }
    
    void BasicShoot()
    {
        int workingIndex = FindShot();
        cooldownTimer = 0;
        shots[workingIndex].transform.position = shotPoint.position;
        shots[workingIndex].GetComponent<BasicShotScript>().SetDirection(direction);
    }

    private int FindShot()
    {
        for (int i = 0; i <= 10; i++)
        {
            if (!shots[i].activeInHierarchy)
            {
                return i;
            }
        }

        return 0;
    }
}
