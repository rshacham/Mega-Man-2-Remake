using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private bool direction;
    [SerializeField] private float newRoomX;
    [SerializeField] private float newRoomY;
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
        print("hey");
        if (megaMan.CompareTag("MegaMan"))
        {
            GameManager._shared.cameraPosX = newRoomX;
            GameManager._shared.cameraPosY = newRoomY;
            GameManager._shared.cameraDirection = direction;
        }
    }
}
