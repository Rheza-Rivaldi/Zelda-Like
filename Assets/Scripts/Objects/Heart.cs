using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    public FloatValue playerHealth;
    public FloatValue heartContainer;
    public float healthValue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            if(playerHealth.RuntimeValue < heartContainer.initialValue *2f){
                playerHealth.RuntimeValue += healthValue;
                if(playerHealth.RuntimeValue > heartContainer.initialValue *2f){
                    playerHealth.RuntimeValue = heartContainer.initialValue *2f;
                    powerUpSignal.RaiseSignal();
                    Destroy(this.gameObject);
                }else if(playerHealth.RuntimeValue <= heartContainer.initialValue *2f){
                    powerUpSignal.RaiseSignal();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
