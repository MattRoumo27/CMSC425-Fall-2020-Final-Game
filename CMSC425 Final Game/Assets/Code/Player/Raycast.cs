using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{

    private GameObject raycastedObj;

    [SerializeField] private int rayLength = 2;
    [SerializeField] private LayerMask layerMaskInteract;

    [SerializeField] private Image uiCrosshair;

    public GameObject ARTooltip;
    public GameObject player;
    GameObject tooltip;

    GameObject tip = null;
    bool notRotated;

    private float tooltipDuration = 0.2f;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
 
        tooltipDuration -= Time.deltaTime;
        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (hit.collider.CompareTag("AR") || hit.collider.CompareTag("Pistol"))
            {
                raycastedObj = hit.collider.gameObject;

                tooltipDuration = 0.2f;

                //change crosshair
                CrossHairActive();


                if (tooltip == null)
                    tooltip = interactable.transform.GetChild(3).gameObject;

                if (tooltip.activeSelf == false)
                {
                    tooltip.SetActive(true);
                    tooltipDuration = 1f;
                    notRotated = true;
                }

                if (notRotated == true)
                {
                    notRotated = false;

                  //  tooltip.transform.LookAt(player.transform);
                    
                    float xDiff = player.transform.position.x - interactable.transform.position.x;
                    float zDiff = player.transform.position.z - interactable.transform.position.z;

                    if (Mathf.Abs(xDiff) > Mathf.Abs(zDiff))
                    {
                        if (interactable.transform.position.x > player.transform.position.x)
                        {
                            tooltip.transform.localEulerAngles = new Vector3(90, 0, -90);
                        }
                        else
                        {
                            tooltip.transform.localEulerAngles = new Vector3(-90, 0, -90);
                        }

                    }
                    else
                    {
                        if (interactable.transform.position.z > player.transform.position.z)
                        {
                            tooltip.transform.localEulerAngles = new Vector3(0, 0, -90);
                        }
                        else
                        {
                            tooltip.transform.localEulerAngles = new Vector3(180, 0, -90);
                        }
                    }
                    
                }

                if (hit.collider.CompareTag("AR"))
                {
                    tooltip.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = EquipmentManager.instance.currentEquipment[0].damageModifier.ToString();
                    tooltip.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = interactable.GetComponent<EquipmentPickup>().equipment.damageModifier.ToString();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                            tooltip.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = EquipmentManager.instance.currentEquipment[0].damageModifier.ToString();
                            tooltip.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = interactable.GetComponent<EquipmentPickup>().equipment.damageModifier.ToString();
                            tooltipDuration = 0.2f;

                        //Add Weapon to Equipment
                        interactable.Interact();
                    }


                    }

                else if (hit.collider.CompareTag("Pistol")){
                    tooltip.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = EquipmentManager.instance.currentEquipment[1].damageModifier.ToString();
                    tooltip.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = interactable.GetComponent<EquipmentPickup>().equipment.damageModifier.ToString();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                       
                        tooltip.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = EquipmentManager.instance.currentEquipment[1].damageModifier.ToString();
                        tooltip.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = interactable.GetComponent<EquipmentPickup>().equipment.damageModifier.ToString();
                        tooltipDuration = 0.2f;
                        

                        //Add Weapon to Equipment
                        interactable.Interact();
                    }

                }

             

            }
            else if (hit.collider.CompareTag("HealthPack")){
                CrossHairActive();
                if (Input.GetKeyDown(KeyCode.E))
                    interactable.Interact();
            }
            else if (hit.collider.CompareTag("ItemChest")){
                CrossHairActive();
                if (Input.GetKeyDown(KeyCode.E)) {
                    Debug.Log(interactable);
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

        if (tooltip != null && tooltip.activeSelf == true && tooltipDuration <= 0)
        {
            tooltip.SetActive(false);
            tooltip = null;
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
