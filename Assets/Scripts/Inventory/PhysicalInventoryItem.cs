using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private InventoryItems thisItem;


    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }

    void AddItemToInventory(){
        if(playerInventory != null && thisItem != null){
            if(playerInventory.myInventory.Contains(thisItem)){
                thisItem.itemHeld++;
            }
            else{
                playerInventory.myInventory.Add(thisItem);
                thisItem.itemHeld++;
            }
        }
    }

}
