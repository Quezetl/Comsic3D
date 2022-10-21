using System.Collections;
using System.Collections.Generic;
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

    void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        CheckGrounded();
        CheckSprintCD();

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        if (Input.GetKey(KeyCode.LeftShift) && !sprintRecharge && canSprint)
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

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log($"{this.transform.localScale}");
            this.transform.localScale = new Vector3(1.0f, .5f, 1.0f);
            this.transform.Translate(new Vector3(0, -.5f, 0));
        }
        else
        {
            this.transform.localScale = new Vector3(1.0f, 1f, 1.0f);
            this.transform.Translate(new Vector3(0, 0.5f, 0));
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
