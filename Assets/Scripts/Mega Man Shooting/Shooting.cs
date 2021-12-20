using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float shootingCooldown;
    [SerializeField] private GameObject[] shots;
    private float cooldownTimer = 10000;
    private Rigidbody2D megaMan;
    private Transform myShooter;
    private float direction;
    private Animator megaManAnimator;
    // Start is called before the first frame update

    private void Awake()
    {
        direction = 1;
        megaMan = GetComponentInParent<Rigidbody2D>();
        myShooter = GetComponent<Transform>();
        megaManAnimator = GetComponentInParent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && cooldownTimer > shootingCooldown & GameManager._shared.isLadder is false)
        {
            BasicShoot();
            megaManAnimator.SetBool("Shoot", true);
        }
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer > shootingCooldown + 0.1f)
        {
            megaManAnimator.SetBool("Shoot", false);
        }

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
        shots[workingIndex].transform.position = myShooter.position;
        shots[workingIndex].GetComponent<BasicShotScript>().SetDirection(direction);
        GameManager._shared.PlaySound("basicBullet");
        megaManAnimator.SetTrigger("Shoot");
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
