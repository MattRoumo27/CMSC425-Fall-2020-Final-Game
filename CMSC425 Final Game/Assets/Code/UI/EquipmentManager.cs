using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

     public  Equipment[] currentEquipment;

    Inventory inventory;

    public Equipment[] startingEquipment;
    public GameObject[] objectPrefabs;
    public GameObject player;
    public GameObject primaryWeapon;
    public GameObject secondaryWeapon;

    private void Start()
    {
        currentEquipment = new Equipment[System.Enum.GetNames(typeof(EquipmentSlot)).Length];
        inventory = Inventory.instance;

        for (int i = 0; i < startingEquipment.Length; i++)
        {
            Equip(startingEquipment[i]);
        }

    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = currentEquipment[slotIndex];

        if (oldItem != null)
        {
            Drop(oldItem, slotIndex);
        }
           currentEquipment[slotIndex] = newItem;
        ChangeStats(newItem, slotIndex);
        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(newItem, oldItem);
            
        }

    public void Unequip(int slotIndex)
    {
         Equipment oldItem = currentEquipment[slotIndex];

        if (oldItem != null)
        {
            Drop(oldItem, slotIndex);
                currentEquipment[slotIndex] = null;
                if (onEquipmentChanged != null)
                    onEquipmentChanged.Invoke(null, oldItem);
            
        }
    }

    public void Drop(Equipment oldItem, int slotIndex)
    {
        GameObject droppedItem = objectPrefabs[slotIndex];
        droppedItem.GetComponent<EquipmentPickup>().equipment = oldItem;
        Instantiate(droppedItem, player.transform.position + player.transform.forward + new Vector3(0, 0.1f,0) , Quaternion.Euler(0, 0, 90));
    }

    public void ChangeStats(Equipment newItem, int slotIndex)
    {
        if (slotIndex == 0)
        {
            primaryWeapon.GetComponent<Gun>().damage = newItem.damageModifier;
            primaryWeapon.GetComponent<Gun>().currentAmmo = primaryWeapon.GetComponent<Gun>().maxAmmo;
        }
        else if (slotIndex == 1)
        {
            secondaryWeapon.GetComponent<Gun>().damage = newItem.damageModifier;
            secondaryWeapon.GetComponent<Gun>().currentAmmo = secondaryWeapon.GetComponent<Gun>().maxAmmo;
        }
    }


}
