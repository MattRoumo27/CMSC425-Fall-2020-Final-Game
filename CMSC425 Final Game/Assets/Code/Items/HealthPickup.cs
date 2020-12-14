using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactable
{
    public HealthPack healthPack;
    AudioSource audioSource;
    public AudioClip interactSound;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void Start() 
    {
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
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
