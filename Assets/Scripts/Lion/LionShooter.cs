using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionShooter : MonoBehaviour
{
    [SerializeField] private GameObject[] shots;
    [SerializeField] private Transform myShooter;
    private int shotCounter = 0;
    private float singleShotCooldown = 15;
    [SerializeField] private float singleCooldownTimer;
    private float fireCooldown = 15;
    [SerializeField] private float fireCooldownTimer;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (singleShotCooldown > singleCooldownTimer & fireCooldown > fireCooldownTimer)
        {
            BasicShoot();
        }
        fireCooldown += Time.deltaTime;
        singleShotCooldown += Time.deltaTime;
    }   

    void BasicShoot()
    {
        shots[shotCounter].transform.position = new Vector3(myShooter.position.x, myShooter.position.y, -1);
        shots[shotCounter].SetActive(true);
        shotCounter += 1;
        singleShotCooldown = 0;
        if (shotCounter == 7)
        {
            shotCounter = 0;
            fireCooldown = 0;
        }
    }
    
}
