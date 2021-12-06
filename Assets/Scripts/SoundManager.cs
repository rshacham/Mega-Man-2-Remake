using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip jump, basicBullet, rabbitBullet, enemyHit, megaManHit;
    private AudioSource mySource;
    // Start is called before the first frame update
    void Start()
    {
        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    public void PlaySound(string myAudio)
    {
        switch (myAudio)
        {
            case "jump":
                mySource.PlayOneShot(jump);
                break;
            case "basicBullet":
                mySource.PlayOneShot(basicBullet);
                break;
            case "rabbitBullet":
                mySource.PlayOneShot(rabbitBullet);
                break;
            case "enemyHit":
                mySource.PlayOneShot(enemyHit);
                break;
            case "megaManHit":
                mySource.PlayOneShot(megaManHit);
                break;
        }
    }
}
