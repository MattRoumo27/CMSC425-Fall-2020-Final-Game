using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.3f;
    public float jumpForce = 2;
    public float jumpRayCastDistance = 1;

    private Rigidbody rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        Jump();
    }

    private void FixedUpdate() 
    {
        Move();
    }

    private void Move() 
    {
        // Get inputs from 'w', 'a', 's', and 'd' keys
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        // Place input values into a new Vector3 and scale it by the player movement speed
        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed;

        // Calculate the new position where the player will end up
        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);

        // Move to that position with the rigidbody
        rb.MovePosition(newPosition);
    }

    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded()) 
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }
    }

    private bool IsGrounded() 
    {
        return Physics.Raycast(transform.position, Vector3.down, jumpRayCastDistance);
    }
}
