using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShotScript : MonoBehaviour
{
    //Will Handle the behaviour of a single basic bullet
    [SerializeField] private float speed;
    private bool hit; //Did the bullet hit something?
    private float direction; //Will hold the direction that the bullet should go to
    private BoxCollider2D myBoxCollider;

    // Start is called before the first frame update

    void Awake()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return; 
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        hit = true;
        myBoxCollider.enabled = false;
        gameObject.SetActive(false);
        
    }

    public void SetDirection(float _direction)
    {
        //Sets new shot active and sets it's direction
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        myBoxCollider.enabled = true;
    }
}
