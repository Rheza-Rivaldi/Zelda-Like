using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Inventory/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{

    public List<InventoryItems> items = new List<InventoryItems>();

    public InventoryItems GetItem(string itemName)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].itemName == itemName)
            {
                return items[i];
            }
        }

        return null;
    }
}