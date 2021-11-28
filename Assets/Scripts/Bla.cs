using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShot : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float direction;
    private Animator myAnimator;

    private BoxCollider2D myBoxCollider;
    // Start is called before the first frame update

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
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

    private void OnTriggerEnter2D(Collider other)
    {
        hit = true;
        myBoxCollider.enabled = false;
        gameObject.SetActive(false);
    }

    private void SetDirection(float _direction)
    {
        gameObject. SetActive(true);
        hit = false;
        myBoxCollider.enabled = true;
    }
}
