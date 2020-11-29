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
        if (playerManager.getUI() == false)
            RotateCamera();
        // CheckForShooting();
    }

    private void RotateCamera()
    {
        // // Store values of mouse input in a 2D-Vector
        // Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        
        // mouseInput = Vector2.Scale(mouseInput, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));
        
        // // Apply linear interpolation for smooth transitions
        // smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, mouseInput.x, 1f / smoothing);
        // smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, mouseInput.y, 1f / smoothing);

        // currentLookingPosition += smoothedVelocity;

        // transform.localRotation = Quaternion.AngleAxis(-currentLookingPosition.y, Vector3.right);
        // player.transform.localRotation = Quaternion.AngleAxis(currentLookingPosition.x, player.transform.up);
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
