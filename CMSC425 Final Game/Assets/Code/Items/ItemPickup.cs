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
        bool successfulPickup;

        successfulPickup = Inventory.instance.Add(item);
        if (successfulPickup)
            Destroy(gameObject);
    }
        
}
