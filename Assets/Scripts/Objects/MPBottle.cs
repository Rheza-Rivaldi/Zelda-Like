using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPBottle : PowerUp
{
    //public Inventory playerInventory;
    public FloatValue playerMP;
    public float mPValue;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            playerMP.RuntimeValue += mPValue;
            powerUpSignal.RaiseSignal();
            Destroy(this.gameObject);
        }
    }
}
