using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPBottle : PowerUp
{
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            powerUpSignal.RaiseSignal();
            Destroy(this.gameObject);
        }
    }
}
