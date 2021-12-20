using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LionShooter : MonoBehaviour
{
    [SerializeField] private GameObject[] shots;
    [SerializeField] private GameObject lionFire;
    [SerializeField] private Transform myShooter;
    private int shotCounter = 0;
    [SerializeField] private float ballsAmount;
    [SerializeField] float ballCoolDown = 1; //cool down time between single fire balls
    [SerializeField] private float ballTimer; //Timer for the time since the last ball was shot
    //[SerializeField] private float fireCoolDown = 15; //Time between lion attacks
    //[SerializeField] private float fireTimer; //Timer for the time between lion attacks
    private bool shouldShoot = false;

    //private bool fireBalls = false; //If true, will fire balls
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (shouldShoot & ballTimer > ballCoolDown)
        {
            BasicShoot();
        }
        //if (ballTimer > ballCoolDown & fireTimer > fireCoolDown)
        //{
        //    BasicShoot();
        //}
        //fireTimer += Time.deltaTime;
        ballTimer += Time.deltaTime;
    }   

    void BasicShoot()
    {
        shots[shotCounter].SetActive(true);
        shotCounter += 1;
        ballTimer = 0;
        if (shotCounter == ballsAmount) //stops the lion attack
        {
            shotCounter = 0;
            shouldShoot = false;
        }
    }
    
    public void StartShoot()
    {
        ballsAmount = Random.Range(3, 8);
        shouldShoot = true;
    }

}
