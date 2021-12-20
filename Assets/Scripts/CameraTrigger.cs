using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] myObjects; //objects to activate when entering the trigger
    [SerializeField] private bool direction;
    [SerializeField] private float newRoomX;
    [SerializeField] private float newRoomY;
    [SerializeField] private float newRightBoundary;
    [SerializeField] private float newLeftBoundary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D megaMan)
    {
        if (megaMan.CompareTag("MegaMan"))
        {
            if (direction is true)
            {
                GameManager._shared.cameraPosX = newRoomX;
                GameManager._shared.cameraPosY = newRoomY;
            }

            else
            {
                GameManager._shared.cameraLeftBoundary = newRoomX;
                GameManager._shared.cameraRightBoundary = newRoomY;
            }
            
            GameManager._shared.cameraDirection = direction;

        }

        int a = myObjects.Length;
        for (int i = 0; i < myObjects.Length; ++i)
        {
            myObjects[i].SetActive(true);
        }
        
        }
}
