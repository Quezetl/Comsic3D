using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float gravity;
    public float jumpHeight;
    public float walk;
    public float sprint;
    public float sprintCap;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    Vector3 velocity;
    float speed;
    float sprintDur;
    bool isGrounded;
    bool canSprint;
    bool sprintRecharge;
    bool isPaused;


    bool inside = true;
    void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void CheckPaused()
    {
        if (Time.timeScale == 1)
            isPaused = false;
        else if (Time.timeScale == 0)
            isPaused = true;
    }

    void CheckSprintCD()
    {
        if (sprintDur <= 0)
        {
            sprintRecharge = true;
            canSprint = false;
        }

        if (sprintDur >= sprintCap)
        {
            sprintRecharge = false;
            canSprint = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        doorCheck();
        insideSpeed();

        CheckPaused();
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        CheckGrounded();
        CheckSprintCD();

        if (isGrounded && velocity.y < 0 && !isPaused)
        {
            velocity.y = -2f;
        }


        if (Input.GetKey(KeyCode.LeftShift) && !sprintRecharge && canSprint && !isPaused)
        {
            speed = sprint;
            sprintDur -= 1f * Time.deltaTime;
        }
        else
        {
            speed = walk;
            if(sprintDur < sprintCap)
                sprintDur += 1.5f * Time.deltaTime;
        }

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded && !isPaused)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetKey(KeyCode.LeftControl) && !isPaused)
        {
            for (float i = 1.0f; i > 0.5; i -= 0.001f)
            {
                this.transform.localScale = new Vector3(1.0f, i, 1.0f);
                this.transform.Translate(new Vector3(0, -i, 0));
            }

        }
        else
        {
            this.transform.localScale = new Vector3(1.0f, 1f, 1.0f);
            this.transform.Translate(new Vector3(0, 0.5f, 0));
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }


    void insideSpeed()
    {
        if (inside)
        {
            walk = 10f;
            sprint = 20f;
            sprintCap = 3f;
        }
        else
        {
            walk = 25f;
            sprint = 40f;
            sprintCap = 5f;
        }
    }
    void doorCheck()
    {
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit mousePos);

        if (!hit)
            return;
        if (!mousePos.collider.CompareTag("door"))
            return;

        if (!inside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                controller.enabled = false;
                this.transform.position = new Vector3(815f, -216f, -1678f);
                Debug.Log("inside condition met");
                controller.enabled = true;
                inside = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                controller.enabled = false;
                this.transform.position = new Vector3(254f, 66f, -555);
                Debug.Log("inside condition met");
                controller.enabled = true;
                inside = false;
            }

        }


    }


    public float getSpeed()
    {
        return speed;
    }
}
