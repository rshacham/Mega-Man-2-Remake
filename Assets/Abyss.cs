using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Abyss : MonoBehaviour
{
    //Will kill mega man if he falls into the abyss
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MegaMan")
        {
            GameManager._shared.TakeDamage(20);
        }
    }
}
