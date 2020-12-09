using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{

    public Image equipmentIcon;
    public Image defaultIcon;
    public Button removeButton;
    public Text damageText;
    Equipment equipment;

    public void AddItem(Equipment newEquipment)
    {
        equipment = newEquipment;

        equipmentIcon.sprite = equipment.icon;
        damageText.text = newEquipment.damageModifier.ToString();
    }

    public void ClearSlot()
    {
        equipment = null;

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
