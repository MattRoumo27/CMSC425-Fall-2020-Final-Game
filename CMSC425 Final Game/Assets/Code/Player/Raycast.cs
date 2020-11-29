using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{

    private GameObject raycastedObj;

    [SerializeField] private int rayLength = 10;
    [SerializeField] private LayerMask layerMaskInteract;

    [SerializeField] private Image uiCrosshair;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (hit.collider.CompareTag("Inventory Object"))
            {
                raycastedObj = hit.collider.gameObject;

                //change crosshair
                CrossHairActive();


                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Interacted with an object");
                    interactable.Interact();
                }
            }
        }

        else
        {
            //crosshair normal
            if (uiCrosshair.color == Color.red)
                CrossHairNormal();
        }
    }

    void CrossHairActive()
    {
        uiCrosshair.color = Color.red;
    }

    void CrossHairNormal()
    {
        uiCrosshair.color = Color.white;
    }

}
