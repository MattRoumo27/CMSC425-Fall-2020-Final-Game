using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float lookSensitivity = 2;
    public float smoothing = 5;

    public PlayerManager playerManager;

    private GameObject player;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPosition;

    public float mouseSensitivity = 1000f;

    public Transform playerBody;
    public CameraManager cameraManager;

    float xRotation = 0f;

    private void Start() 
    {
        player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;

        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    private void Update() 
    {
        //Only rotate camera if the UI is not opened
        if (playerManager.getUI() == false && cameraManager.canMovePlayer)
            RotateCamera();

        // CheckForShooting();
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void CheckForShooting() 
    {
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            RaycastHit whatIHit;
            if (Physics.Raycast(transform.position, transform.forward, out whatIHit, Mathf.Infinity))
            {
                IDamageable damageable = whatIHit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    Debug.Log(whatIHit.collider.name);
                    damageable.DealDamage(10);
                }
            }
        }
    }
    
}
