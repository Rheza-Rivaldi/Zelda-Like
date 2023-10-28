using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItems : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public int itemHeld;
    public bool isUnique;
    public bool isUsable;
    public UnityEvent thisEvent;

    public void Use(){
        if(itemHeld > 0){
            thisEvent.Invoke();
        }
    }

    public void DecreaseItemAmount(){
        itemHeld--;
        if(itemHeld < 0){
            itemHeld = 0;
        }
    }
}
