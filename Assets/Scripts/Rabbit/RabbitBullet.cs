using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;

    private BoxCollider2D myBoxCollider;
    void Awake()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        
    }
    
    void FixedUpdate()
    {
        float movementSpeed = speed * Time.deltaTime * -1;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("MegaMan"))
        {
            GameManager._shared.TakeDamage(3);
        }
        gameObject.SetActive(false);
    }
}
