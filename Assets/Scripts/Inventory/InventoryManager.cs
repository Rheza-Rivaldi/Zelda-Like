using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    [Header("UI Component Reference")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryHolder;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItems currentItem;


    public void SetInventoryText(string itemName, string itemDescription, bool buttonActive, InventoryItems newItem){
        nameText.text = itemName;
        descriptionText.text = itemDescription;
        useButton.SetActive(buttonActive);
        currentItem = newItem;

    }

    void MakeInventorySlots(){
        if(playerInventory != null){
            for(int i = 0; i < playerInventory.myInventory.Count; i++){
                if(playerInventory.myInventory[i].itemHeld > 0){
                    GameObject temp = Instantiate(blankInventorySlot, inventoryHolder.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryHolder.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if(newSlot != null){
                        newSlot.SetupInventory(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }

    void ClearInventorySlots(){
        for(int i = 0; i < inventoryHolder.transform.childCount; i++){
            Destroy(inventoryHolder.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonEvent(){
        if(currentItem != null && currentItem.isUsable){
            currentItem.Use();
            RefreshInventory();
            if(currentItem.itemHeld <= 0){
                SetInventoryText("", "", false, currentItem);
            }
        }
    }

    public void RefreshInventory(){
        ClearInventorySlots();
        MakeInventorySlots();
    }

    void OnEnable()
    {
        RefreshInventory();
        SetInventoryText("", "", false, currentItem);
    }


}
