using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPManager : MonoBehaviour
{
    public Slider mPSlider;
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        mPSlider.maxValue = playerInventory.maxMP;
        mPSlider.value = playerInventory.maxMP;
        playerInventory.currentMP = playerInventory.maxMP;
    }

    public void IncreaseMP(){
        playerInventory.currentMP += 1;
        if(playerInventory.currentMP > mPSlider.maxValue){
            playerInventory.currentMP = mPSlider.maxValue;
        }
        mPSlider.value = playerInventory.currentMP;
    }

    public void DecreaseMP(){
        playerInventory.currentMP -= 1;
        if(playerInventory.currentMP < 0){
            playerInventory.currentMP = 0;
        }
        mPSlider.value = playerInventory.currentMP;
    }

}
