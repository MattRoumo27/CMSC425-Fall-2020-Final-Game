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

    private void Start()
    {
        currentEquipment = new Equipment[System.Enum.GetNames(typeof(EquipmentSlot)).Length];
        inventory = Inventory.instance;
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = currentEquipment[slotIndex];

        if (oldItem != null)
        {
            inventory.Add(oldItem);
        }
           currentEquipment[slotIndex] = newItem;

        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(newItem, oldItem);
            
        }

    public void Unequip(int slotIndex)
    {
         Equipment oldItem = currentEquipment[slotIndex];

        if (oldItem != null)
        {
            if (inventory.Add(oldItem) != false)
            {
                currentEquipment[slotIndex] = null;
                if (onEquipmentChanged != null)
                    onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }


}
