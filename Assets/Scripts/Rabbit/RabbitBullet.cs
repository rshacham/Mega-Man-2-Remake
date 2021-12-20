using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    public Transform megaMan;
    public float myDirection = -1; //if -1 will go right, if 1 will go left

    private BoxCollider2D myBoxCollider;
    void Awake()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        
    }
    
    void FixedUpdate()
    {
        float movementSpeed = speed * Time.deltaTime * myDirection;
        transform.Translate(movementSpeed, (megaMan.position.y - transform.position.y)/40f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("MegaMan"))
        {
            GameManager._shared.TakeDamage(3);
        }
        gameObject.SetActive(false);
    }

    public void ChangePosition(Vector3 position)
    {
        transform.position = position;
        myDirection *= -1;
    }
}
