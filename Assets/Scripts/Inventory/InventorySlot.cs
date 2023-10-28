using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("UI Component reference")]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private Image itemImage;

    [Header("Item Variables")]
    public InventoryItems thisItem;
    public InventoryManager thisManager;
    

    public void SetupInventory(InventoryItems newItem, InventoryManager newManager){
        thisItem = newItem;
        thisManager = newManager;
        if(thisItem != null){
            itemImage.sprite = thisItem.itemSprite;
            itemNumberText.text = "" + thisItem.itemHeld;
        }
    }

    public void ChosenItem(){
        if(thisItem != null){
            thisManager.SetInventoryText(thisItem.itemName, thisItem.itemDescription, thisItem.isUsable, thisItem);
        }
    }


}
