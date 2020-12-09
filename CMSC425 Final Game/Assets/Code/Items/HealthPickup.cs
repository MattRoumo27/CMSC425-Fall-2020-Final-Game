using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactable
{
    public HealthPack healthPack;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {

        bool successfulPickup = HealthManager.instance.AddHealthPack();
        if (successfulPickup)
            Destroy(gameObject);
    }
}
