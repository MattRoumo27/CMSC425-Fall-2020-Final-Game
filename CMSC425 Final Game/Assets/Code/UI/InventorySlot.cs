using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;
    Item item;

  //  public PlayerController playerController;

    private void Start()
    {
       // playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    
    public void UseItem()
    {
        if (item != null)
        {
          /*  if (playerController.IsInteracting() && playerController.InteractingWith() is Chest)
            {
                Chest chest = (Chest)playerController.InteractingWith();
                chest.Add(item);
                Inventory.instance.Remove(item);
                Inventory.instance.onItemChangedCallback.Invoke();
            } */
          //  else
           // {
                item.Use();
            //}
        }
    } 
}
