using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitShooter : MonoBehaviour
{
    public RabbitBullet bulletScript;
    [SerializeField] private GameObject rabbitShot;
    [SerializeField] private Transform shooterTransform;
    [SerializeField] private float xPosition;
    private Vector3 shooterPosition;

    public void Awake()
    {

    }

    public void RabbitShot()
    {
        rabbitShot.transform.position = new Vector3(shooterTransform.position.x, shooterTransform.position.y, -1);
        rabbitShot.SetActive(true);
        GameManager._shared.PlaySound("rabbitBullet");
    }

    public void ChangePosition(bool flip)
    {
        if (flip is false)
        {
            shooterTransform.localPosition = new Vector3(shooterTransform.localPosition.x * -1, shooterTransform.localPosition.y,
                shooterTransform.localPosition.z);
                bulletScript.ChangePosition(shooterPosition);
        }

        else
        {
            shooterTransform.localPosition =
                shooterTransform.localPosition = new Vector3(shooterTransform.localPosition.x * -1, shooterTransform.localPosition.y,
                    shooterTransform.localPosition.z);
            bulletScript.ChangePosition(shooterPosition);

        }
    }
}
