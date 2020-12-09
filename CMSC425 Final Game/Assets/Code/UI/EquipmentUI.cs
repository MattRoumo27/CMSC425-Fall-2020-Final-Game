using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{

    public Transform itemsParent;

    EquipmentManager equipment;

    EquipSlot[] slots;

    private void Start()
    {
        equipment = EquipmentManager.instance;
        equipment.onEquipmentChanged += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<EquipSlot>();
    }

    public void UpdateUI(Equipment newItem, Equipment oldItem)
    {
        for (int i = 0; i < equipment.currentEquipment.Length; i++)
        {
            if (equipment.currentEquipment[i] != null)
            {

                slots[i].AddItem(equipment.currentEquipment[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
