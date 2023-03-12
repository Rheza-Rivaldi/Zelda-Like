using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public enum DoorType{
        key,
        enemy,
        button
    }
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public GameObject doorGameobject;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Z)){
            if(playerInRange && thisDoorType == DoorType.key){
                //check key amount
                if(playerInventory.numberOfKeys > 0){
                    playerInventory.numberOfKeys--;
                    OpenDoor();
                }
            }
        }
    }

    public void OpenDoor(){
        open = true;
        doorGameobject.SetActive(false);
    }
    public void CloseDoor(){

    }
}
