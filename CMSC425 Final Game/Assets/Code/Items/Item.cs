using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

   new public string name = "new name";
   public Sprite icon = null;
 

    public virtual void Use()
    {
        
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}
