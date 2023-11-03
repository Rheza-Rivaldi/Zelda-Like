using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHealthSystem : MonoBehaviour
{
    public FloatValue objectHealth;
    public float currentHealth;


    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = objectHealth.RuntimeValue;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void IncreaseHealthPoint(float amountToIncrease){
        currentHealth += amountToIncrease;
        if(currentHealth > objectHealth.RuntimeValue){
            currentHealth = objectHealth.RuntimeValue;
        }
        
    }

    public virtual void DecreaseHealthPoint(float amountToDecrease){
        currentHealth -= amountToDecrease;
        if(currentHealth < 0){
            currentHealth = 0;
        }
    }
}
