using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float lookSensitivity = 2;
    public float smoothing = 5;

    private GameObject player;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPosition;

    private void Start() 
    {
        player = transform.parent.gameObject;
    }

    private void Update() 
    {
        RotateCamera();
        CheckForShooting();
    }

    private void RotateCamera()
    {
        // Store values of mouse input in a 2D-Vector
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        
        mouseInput = Vector2.Scale(mouseInput, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));
        
        // Apply linear interpolation for smooth transitions
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, mouseInput.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, mouseInput.y, 1f / smoothing);

        currentLookingPosition += smoothedVelocity;

        transform.localRotation = Quaternion.AngleAxis(-currentLookingPosition.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(currentLookingPosition.x, player.transform.up);
    }

    private void CheckForShooting() 
    {
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            RaycastHit whatIHit;
            if (Physics.Raycast(transform.position, transform.forward, out whatIHit, Mathf.Infinity))
            {
                Debug.Log(whatIHit.collider.name);
            }
        }
    }
    
}
