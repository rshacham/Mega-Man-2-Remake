using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rabbit : MonoBehaviour
{

    private Transform rabbitPosition;
    private float currentAngle;
    private bool didJump = false;
    private bool shouldShoot = false;
    private float shootingTimer;
    [SerializeField] private float startingX, startingY;
    [SerializeField] public int rabbitLife;
    [SerializeField] private RabbitShooter rabbitShooter;
    [SerializeField] private float shootingCooldown;


    public void Awake()
    {
        rabbitPosition = GetComponent<Transform>();
        currentAngle = 180;
    }

    public void RabbitJump()
    {
        rabbitPosition.position = new Vector3(startingX + (1.5f * Mathf.Cos(currentAngle * Mathf.PI / 180f)),
            startingY + (1.5f * Mathf.Sin(currentAngle * Mathf.PI / 180f)), 0);
        currentAngle += 6;
        if (currentAngle == 180)
        {
            shouldShoot = true;
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
            rabbitLife -= 1;
            GameManager._shared.PlaySound("enemyHit");
            if (rabbitLife == 0)
            {
                gameObject.SetActive(false);
            }
        }

        if (trigger.CompareTag("MegaMan"))
        {
            GameManager._shared.TakeDamage(20);
        }
    }
}
