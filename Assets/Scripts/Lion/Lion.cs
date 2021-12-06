using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : MonoBehaviour
{
    [SerializeField] private int lionLife;
    [SerializeField] private GameObject myLion;

    private void Awake()
    {

    }

    private void Start()
    {
    }

    private void Update()
    {
        if (lionLife <= 0)
        {
            myLion.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("MegaMan"))
        {
            GameManager._shared.TakeDamage(20);

        }

        if (collider.CompareTag("BasicShots"))
        {
            lionLife -= 1;
            GameManager._shared.PlaySound("enemyHit");
        }
    }
}
