using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerLook : MonoBehaviour
{
    string shipmsg;
    int count = 0;
    float mouseX;
    float mouseY;
    bool paused;
    public float mouseSensitivity;

    public Transform playerBody;

    float xRotation = 0f;


    public GameObject dialoguebox;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
        shipmsg = "Is that… “Galactic Federation”  property?\nThey look like they had a rougher landing than me. Guess their big fancy ships are just for show.\nWell, I hope they’re in a good enough mood to share some fuel.";
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
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit mousePos);

        if (mousePos.collider.CompareTag("Ship") && count == 0)
        {
            shipdialogue();
            count++;
        }

    }

    void shipdialogue() 
    { 
        dialoguebox.GetComponentInChildren<TMPro.TextMeshProUGUI>(dialoguebox).text = shipmsg;
        dialoguebox.SetActive(true);
        count++;
        Invoke("disableDialogue", 3f);
     }


    void disableDialogue()
    {
        dialoguebox.SetActive(false);
    }

}