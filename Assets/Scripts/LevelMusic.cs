using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    public AudioClip music;
    private AudioSource mySource;
    void Start()
    {
        mySource = GetComponent<AudioSource>();
        mySource.PlayOneShot(music);
    }
}
