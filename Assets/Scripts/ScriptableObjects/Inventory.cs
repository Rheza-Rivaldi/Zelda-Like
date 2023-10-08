using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;
    public int coins;
    public float maxMP = 10;
    public float currentMP;

    public void AddItem(Item itemToAdd){
        if(itemToAdd.isKey){
            numberOfKeys++;
        }
        else{
            //check if the item already in inventory
            if(!items.Contains(itemToAdd)){
                items.Add(itemToAdd);
            }
        }
    }

    public bool CheckForItem(Item item){
        if(items.Contains(item)){
            return true;
        }
        else{
            return false;
        }
    }

    public void MPUsage(float mPCost){
        currentMP -= mPCost;
    }
}
