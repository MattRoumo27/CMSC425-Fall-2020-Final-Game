using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactable
{
    public HealthPack healthPack;
    public AudioSource audioSource;
    public AudioClip interactSound;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {

        bool successfulPickup = HealthManager.instance.AddHealthPack();
        if (successfulPickup) {
            audioSource.PlayOneShot(interactSound);
            Destroy(gameObject);
        }
    }
}
