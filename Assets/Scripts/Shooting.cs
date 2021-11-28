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
    private Movement playerMovement;
    private float cooldownTimer = 10000;
    // Start is called before the first frame update

    private void Awake()
    {
        playerMovement = GetComponent<Movement>();
        
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
    }
    
    void BasicShoot()
    {
        int workingIndex = FindShot();
        cooldownTimer = 0;
        shots[workingIndex].transform.position = shotPoint.position;
        shots[workingIndex].GetComponent<BasicShotScript>().SetDirection(Mathf.Sign(transform.localScale.x));
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
