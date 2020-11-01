using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
       // isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move;

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            else 
                velocity.y += gravity * Time.deltaTime;
     
            move = transform.right * x * speed + transform.forward * z * speed;
        }

        else
        {
            velocity.y += gravity * Time.deltaTime;
            move = transform.right * x * (speed/2) + transform.forward * z * (speed/2);
        }

        move += transform.up * velocity.y;
        controller.Move(move * Time.deltaTime);

      
    }
}
