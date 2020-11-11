using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public Rigidbody bullet;
    Vector3 verticalStep;
    Vector3 horizontalStep;
    public float movementSpeed = 2;
    const int bulletSpeed = 1000;
    public int rateOfFire = 50;
    private int fireRateTimer = 0;
    private float delta_x;
    private float delta_y;

    private float currentRotationX = 0f;
    private float currentRotationY = 0f;
    private float smooth = 5.0f;
    public float cameraSpeed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        verticalStep = movementSpeed * Vector3.forward;
        horizontalStep = movementSpeed * Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        HandleGunFire();
    }

    private void FixedUpdate() 
    {
        HandleMovement();
        HandleCameraRotation();
    }

    // Smoothly translates the player movement
    void HandleMovement() 
    {
        transform.Translate(verticalStep * Time.deltaTime * Input.GetAxis("Vertical"));
        transform.Translate(horizontalStep * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    // Smoothly rotates the camera based off of mouse inputs
    void HandleCameraRotation()
    {
        // Calculate values for next rotation
        delta_x = Input.GetAxis("Mouse Y");
        delta_y = Input.GetAxis("Mouse X");
        currentRotationX = Mathf.Clamp(currentRotationX - delta_x * cameraSpeed * Time.deltaTime, -80f, 80f);
        currentRotationY += delta_y * cameraSpeed * Time.deltaTime;

        // Define the rotation
        Quaternion target = Quaternion.Euler(currentRotationX, currentRotationY, 0);
        this.transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
    }

    // Checks if the player has pressed the fire button
    void HandleGunFire()
    {
        if (Input.GetAxis("Fire1") != 0 && fireRateTimer <= 0)
        {
            Vector3 offset = new Vector3(0, 0.005100012f, 0.371f);
            Vector3 bulletStartingPoint = transform.position + offset;
            Rigidbody clone = Instantiate(bullet, bulletStartingPoint, Quaternion.Euler(90, 0, 0));

            // Give the cloned object an initial velocity along the current 
            // object's Z axis
            clone.velocity = transform.TransformDirection(transform.forward * bulletSpeed);
            fireRateTimer = rateOfFire;
        }
        fireRateTimer--;
    }
}
