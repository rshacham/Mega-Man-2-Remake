using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitShooter : MonoBehaviour
{
    [SerializeField] private GameObject rabbitShot;
    [SerializeField] private Transform shooterTransform;
    
    public void RabbitShot()
    {
        rabbitShot.transform.position = new Vector3(shooterTransform.position.x, shooterTransform.position.y, -1);
        rabbitShot.SetActive(true);
        GameManager._shared.PlaySound("rabbitBullet");
    }
}
