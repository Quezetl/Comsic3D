using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour
{
    float mouseX;
    float mouseY;
    bool paused;
    public float mouseSensitivity;

    public Transform playerBody;

    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
    }
    
    void checkGameStatus()
    {
        if (Time.timeScale == 1)
            paused = false;
        else if (Time.timeScale == 0)
            paused = true;
    }
    // Update is called once per frame
    void Update()
    {
        checkGameStatus();
        if (!paused)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);


            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }


    }
}
