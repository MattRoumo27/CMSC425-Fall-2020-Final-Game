using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.3f;
    public float jumpHeight = 2;
    public float jumpRayCastDistance = 1;

    public CharacterController controller;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    private void Update() 
    {
        Jump();
        Move();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }
    }

    private void Move() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump() 
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     if (IsGrounded()) 
        //     {
        //         //controller.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        //     }
        // }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private bool IsGrounded() 
    {
        return Physics.Raycast(transform.position, Vector3.down, jumpRayCastDistance);
    }
}
