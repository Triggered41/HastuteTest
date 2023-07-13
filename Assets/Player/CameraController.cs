using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 mouseSensitivity;
    public Transform player;
    public Transform camHolder;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraLook();
    }

    void CameraLook(){
    float mouseX = -Input.GetAxis("Mouse Y") * mouseSensitivity.y * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse X") * mouseSensitivity.x * Time.deltaTime;
    
    camHolder.Rotate(mouseX, 0f, 0f);

    player.RotateAround(player.transform.position, player.transform.up, mouseY);
}
}
