using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
     //   DontDestroyOnLoad(this.gameObject);
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public int space = 20;

 
    public bool Add(Item item)
    {
        if (item is Stackable)
        {
            if (items.Contains(item))
            {
                int index = items.IndexOf(item);
                Stackable tempItem = (Stackable)items[index];
                tempItem.AddToCount(((Stackable)item).GetCount());
                if (onItemChangedCallback != null)
                  onItemChangedCallback.Invoke();
            }
            else if (items.Count >= space)
            {
                Debug.Log("Not Enough room");
                return false;
            }
            else
            {
                items.Add(item);
                if (onItemChangedCallback != null)
                    onItemChangedCallback.Invoke();
            }
            return true;
        }
        else
        {
            if (items.Count >= space)
            {
                Debug.Log("Not Enough room");
                return false;
            }

            items.Add(item);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
            return true;
        }
  
    }

    public void SubtractFromStackable(Item item, int valueToSubract)
    {
        if (items.Contains(item))
        {
            int index = items.IndexOf(item);
            if (((Stackable)items[index]).RemoveFromCount(valueToSubract) <= 0)
            {
                if (onItemChangedCallback != null)
                    onItemChangedCallback.Invoke();
                Remove(item);
            }
        }
    }


    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }


}
