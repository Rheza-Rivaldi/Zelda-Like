using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemUseEffect : MonoBehaviour
{

    public Inventory playerInventory;
    public FloatValue playerHP;
    public Signal healthSignal;
    public Signal mpSignal;


    public void HPPotion(int amountToIncrease){
        PlayerHealth playerHealth = GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();
        playerHealth.IncreaseHealthPoint(amountToIncrease);
        //playerHP.RuntimeValue += amountToIncrease;
        healthSignal.RaiseSignal();
    }

    public void MPPotion(int amountToIncrease){
        playerInventory.currentMP += amountToIncrease;
        mpSignal.RaiseSignal();
    }
}
