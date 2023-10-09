using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : PowerUp
{
    public FloatValue playerHealth;
    public FloatValue heartContainer;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            heartContainer.RuntimeValue += 1;
            playerHealth.RuntimeValue = heartContainer.RuntimeValue*2;
            powerUpSignal.RaiseSignal();
            Destroy(this.gameObject);
        }
    }
}
