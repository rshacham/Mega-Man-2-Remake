using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LionFire : MonoBehaviour
{
    [SerializeField] private float speedX; //How much x to reduce in one FixedUpdate
    //[SerializeField] private float speedY;
    private float startingX, startingY;
    [SerializeField] private GameObject fireObject;
    private Transform bulletTransform;
    public Transform shooterTransform;

    // Start is called before the first frame update
    void Start()
    {
        bulletTransform = GetComponent<Transform>();
        startingX = shooterTransform.localPosition.x;
        //startingY = Mathf.Pow(startingX + 0.70f, 2) - 0.8f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        startingX = startingX + speedX;
        startingY = 0.512265f * (startingX * startingX)  +1.09554f * startingX + 0.0464486f;
        bulletTransform.localPosition = new Vector3(startingX, startingY, bulletTransform.localPosition.z);
        if (startingX < -3.29f)
        {
            bulletTransform.localPosition = shooterTransform.localPosition;
            startingX = bulletTransform.localPosition.x;
            fireObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    { 
        if (collider.CompareTag("MegaMan"))
        {
            GameManager._shared.TakeDamage(6);
        }
    }
    
}
