using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPManager : MonoBehaviour
{
    public Slider mPSlider;
    //public Inventory playerInventory;
    public FloatValue playerMP;

    // Start is called before the first frame update
    void Start()
    {
        mPSlider.maxValue = playerMP.initialValue;
        mPSlider.value = playerMP.RuntimeValue;
        playerMP.RuntimeValue = playerMP.initialValue;
    }

    public void UpdateMP(){
        if(playerMP.RuntimeValue > mPSlider.maxValue){
            playerMP.RuntimeValue = mPSlider.maxValue;
        }
        else if(playerMP.RuntimeValue < 0){
            playerMP.RuntimeValue = 0;
        }
        mPSlider.value = playerMP.RuntimeValue;
    }

    /* public void DecreaseMP(){
        if(playerInventory.currentMP < 0){
            playerInventory.currentMP = 0;
        }
        mPSlider.value = playerInventory.currentMP;
    } */

}
