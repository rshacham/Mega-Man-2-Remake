using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject myLion;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("MegaMan"))
        {
            myLion.SetActive(true);
        }
    }
}
