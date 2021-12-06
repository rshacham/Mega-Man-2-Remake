using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject megaMan;
    public Slider lifeSlider;
    public static GameManager _shared;
    public float cameraLeftBoundary;
    public float cameraRightBoundary;
    public float cameraPosX;
    public float cameraPosY;
    public bool cameraDirection; // if false will follow the player, if true camera will position itself on the center of the current room
    public bool isLadder = false;
    public float myLife;
    private float damageCooldown;
    public SoundManager soundManager;

    [SerializeField]
    private float megaLife;

    void Awake()
    {
        _shared = this;
        cameraLeftBoundary = 1.341f;
        cameraRightBoundary = 43.73f;
        cameraDirection = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myLife <= 0)
        {
            megaMan.SetActive(false);
            print("Game Over!");
        }
        damageCooldown -= Time.deltaTime;
        
    }

    public void TakeDamage(float damage)
    {
        if (damageCooldown <= 0)
        {
            myLife -= damage;
            lifeSlider.value = myLife;
            damageCooldown = 1.5f;
            GameManager._shared.PlaySound("megaManHit");
        }
    }

    public void PlaySound(string myAudio)
    {
        soundManager.PlaySound(myAudio);
    }
}
