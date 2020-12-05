using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/StackableItem")]
public class Stackable : Item
{
  public int count = 0;

    public int GetCount()
    {
        return count;
    } 

    public int AddToCount(int numberAdded)
    {
        count += numberAdded;
        return count;
    }
    public int RemoveFromCount(int numberRemoved)
    {
        count -= numberRemoved;
        return count;
    } 
}
