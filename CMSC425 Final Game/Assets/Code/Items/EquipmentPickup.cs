using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPickup : Interactable
{
    public Equipment equipment;
    AudioSource audioSource;
    public AudioClip gunPickup;
    public override void Interact()
    {
        base.Interact();
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("picking up: " + equipment.name);
        EquipmentManager.instance.Equip(equipment);
        audioSource.PlayOneShot(gunPickup);
        Destroy(gameObject);
    }
}
