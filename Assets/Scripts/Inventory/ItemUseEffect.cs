using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseEffect : MonoBehaviour
{

    public Inventory playerInventory;
    public FloatValue playerHP;
    //public Signal itemUseSignal;
    public Signal healthSignal;
    public Signal mpSignal;


    public void HPPotion(int amountToIncrease){
        playerHP.RuntimeValue += amountToIncrease;
        //itemUseSignal.RaiseSignal();
        healthSignal.RaiseSignal();
    }

    public void MPPotion(int amountToIncrease){
        playerInventory.currentMP += amountToIncrease;
        //itemUseSignal.RaiseSignal();
        mpSignal.RaiseSignal();
    }
}
