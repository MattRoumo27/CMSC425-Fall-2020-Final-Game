using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPickup : Interactable
{
    public Equipment equipment;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("picking up: " + equipment.name);
        EquipmentManager.instance.Equip(equipment);
            Destroy(gameObject);
    }
}
