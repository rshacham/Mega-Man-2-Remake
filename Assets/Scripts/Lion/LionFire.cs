using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionFire : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float startingX;
    [SerializeField] private float startingY;

    private Transform bulletTransform;

    // Start is called before the first frame update
    void Start()
    {
        bulletTransform = GetComponent<Transform>();
        startingY = 0.5f * Mathf.Sqrt(startingX);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementSpeedX = speedX * Time.deltaTime * -1;
        float movementSpeedY = speedY * Time.deltaTime * -1;
        transform.Translate(movementSpeedX, movementSpeedY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        {
            if (collider.CompareTag("MegaMan"))
            {
                GameManager._shared.TakeDamage(6);
            }
            gameObject.SetActive(false);
        }
    }
}
