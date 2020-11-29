using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;

    private static InventoryUI inventoryInstance;
    // Start is called before the first frame update

    private void Awake()
    {
    }
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
