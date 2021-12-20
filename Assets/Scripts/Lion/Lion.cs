using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : MonoBehaviour
{
    [SerializeField] private int lionLife;
    [SerializeField] private GameObject myLion;
    private LionShooter shooterScript;
    private Animator myAnimator;
    [SerializeField] private bool finalEnemy; //if true, beating this lion will win the game

    private void Awake()
    {

    }

    private void Start()
    {
        shooterScript = GetComponentInChildren<LionShooter>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (lionLife <= 0)
        {
            myLion.SetActive(false);
            if (finalEnemy)
            {
                GameManager._shared.Win();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("MegaMan"))
        {
            GameManager._shared.TakeDamage(15);

        }

        if (collider.CompareTag("BasicShots"))
        {
            lionLife -= 1;
            myAnimator.SetTrigger("Damage");
            GameManager._shared.PlaySound("enemyHit");
        }
    }

    public void StartShoot()
    {
        shooterScript.StartShoot();
    }
}
