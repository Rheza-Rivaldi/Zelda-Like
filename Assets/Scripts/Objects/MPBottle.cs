using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPBottle : PowerUp
{
    public Inventory playerInventory;
    public float mPValue;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            playerInventory.currentMP += mPValue;
            powerUpSignal.RaiseSignal();
            Destroy(this.gameObject);
        }
    }
}
