using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.3f;
    public float jumpHeight = 2;
    public float jumpRayCastDistance = 1;

    public CharacterController controller;
    public AudioSource audioSource;
    public AudioClip footsteps;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public CameraManager cameraManager;

    private void Update() 
    {
        if (cameraManager.canMovePlayer)
        {
            Jump();
            Move();
            PlayFootStepSounds();
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0) 
            {
                velocity.y = -2f;
            }
        }
        else 
        {
            audioSource.Pause();
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

    private void PlayFootStepSounds() 
    {
        if (isGrounded && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            audioSource.clip = footsteps;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        } 
        else 
        {
            audioSource.Pause();
        }
    }

    private void Jump() 
    {
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
