using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider mySlider;
    public float currentHealth;

    private void Awake()
    {
        mySlider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }
    }

    public void SetHealth(float _health)
    {
        mySlider.value = _health;
    }

    public void TakeDamage(float _damage)
    {
        mySlider.value -= _damage;
    }
}
