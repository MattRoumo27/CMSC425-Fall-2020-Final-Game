using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("picking up: " + item.name);
       bool successfulPickup = Inventory.instance.Add(item);
        if (successfulPickup)
            Destroy(gameObject);
    }

}
