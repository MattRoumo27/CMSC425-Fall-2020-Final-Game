using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{

    public Image equipmentIcon;
    public Image defaultIcon;
    public Button removeButton;
    Equipment equipment;

    public void AddItem(Equipment newEquipment)
    {
        equipment = newEquipment;

        equipmentIcon.sprite = equipment.icon;
        equipmentIcon.enabled = true;
        defaultIcon.enabled = false;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        equipment = null;
        equipmentIcon.sprite = null;
        equipmentIcon.enabled = false;
        defaultIcon.enabled = true;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        EquipmentManager.instance.Unequip((int)equipment.equipSlot);
    }

  /*  public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    } */


}
