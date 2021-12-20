using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject megaMan;
    public Slider lifeSlider;
    public static GameManager _shared;
    //Camera will follow MegaMan Horizontally only when he's right or left of those boundaries
    [SerializeField] public float cameraLeftBoundary; 
    [SerializeField] public float cameraRightBoundary;
    public float cameraPosX;
    public float cameraPosY;
    public bool cameraDirection; // if false will follow the player, if true camera will position itself on the center of the current room
    public bool isLadder = false;
    public float myLife;
    private float damageCooldown;
    public SoundManager soundManager;
    public Animator megaAnimator;
    public GameObject gameOver; //Canvas "Game Over"
    public GameObject gameWon; //Canvas "Won Game"
    private bool win = false; //if true, player has won the game

    [SerializeField]
    private float megaLife;

    void Awake()
    {
        _shared = this;
        cameraLeftBoundary = 1.5316f;
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
            gameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
        
        else if (win)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
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
            megaAnimator.SetTrigger("Damage");
        }
    }

    public void PlaySound(string myAudio)
    {
        soundManager.PlaySound(myAudio);
    }

    public void Win()
    {
        gameWon.SetActive(true);
        win = true;

    }
}
