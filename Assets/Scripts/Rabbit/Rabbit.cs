using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rabbit : MonoBehaviour
{

    private Transform rabbitPosition;
    private SpriteRenderer rabbitRenderer;
    private float currentAngle;
    private bool didJump = false;
    private bool shouldShoot = false;
    private float shootingTimer;
    private float startingX, startingY;
    [SerializeField] public int rabbitLife;
    [SerializeField] private RabbitShooter rabbitShooter;
    [SerializeField] private float shootingCooldown;
    public Transform megaMan;
    private Animator rabbitAnimator;
    [SerializeField] private float jumpTimer; //Time since last jump
    [SerializeField] private float jumpCoolDown; //Cool Down time between 2 jumps


    public void Awake()
    {
        rabbitPosition = GetComponent<Transform>();  
        rabbitRenderer = GetComponent<SpriteRenderer>();
        currentAngle = 180;
        startingX = rabbitPosition.position.x - 1.5f;
        startingY = rabbitPosition.position.y;
        rabbitShooter = GetComponentInChildren<RabbitShooter>();
        rabbitAnimator = GetComponent<Animator>();

    }

    public void RabbitJump()
    {
        currentAngle += 6;
        rabbitPosition.position = new Vector3(startingX + (1.5f * Mathf.Cos(currentAngle * Mathf.PI / 180f)),
            startingY + (1.5f * Mathf.Sin(currentAngle * Mathf.PI / 180f)), 0);
        rabbitAnimator.SetBool("Jump", true);

        

        if (currentAngle == 180)
        {
            shouldShoot = true;
            rabbitAnimator.SetBool("Jump", false);
        }
    }

    private void Update()
    {
        if (shouldShoot & shootingTimer <= 0)
        {
            rabbitShooter.RabbitShot();
            shootingTimer = shootingCooldown;
        }

        shootingTimer -= Time.deltaTime;
        jumpTimer += Time.deltaTime;
    }


    private void FixedUpdate()
    {
        if (currentAngle < 180)
        {
            RabbitJump();
        }
    }

    public void ZeroAngle()
    {
        currentAngle = 0;
    }

    public bool Jump
    {
        get { return didJump;}
        set { didJump = value;}
    }
    
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("BasicShots"))
        {
            rabbitAnimator.SetTrigger("Damage");
            rabbitLife -= 1;
            GameManager._shared.PlaySound("enemyHit");
            if (rabbitLife == 0)
            {
                gameObject.SetActive(false);
            }
        }

        if (trigger.CompareTag("MegaMan"))
        {
            GameManager._shared.TakeDamage(5);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("MegaMan"))
        {
            if ((megaMan.position.x - rabbitPosition.position.x) > 0)
            { 
                rabbitRenderer.flipX = true;
                rabbitShooter.ChangePosition(true);
            }
            else
            {
                rabbitRenderer.flipX = false;
                rabbitShooter.ChangePosition(false);
            }   
        }
    }
}

