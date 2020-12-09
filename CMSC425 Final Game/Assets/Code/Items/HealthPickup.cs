using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactable
{
    public HealthPotion healthPotion;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {

        bool successfulPickup = HealthManager.instance.AddPotion();
        if (successfulPickup)
            Destroy(gameObject);
    }
}
