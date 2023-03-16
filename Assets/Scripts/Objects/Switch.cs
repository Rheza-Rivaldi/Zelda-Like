using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool activeStatus;
    public BoolValue currentSwitchState;
    private SpriteRenderer mySprite;
    public Sprite onSprite;
    public Door thisDoor;


    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        activeStatus = currentSwitchState.runtimeValue;
        
        if(activeStatus){
            ActivateSwitch();
        }
    }

    public void ActivateSwitch(){
        currentSwitchState.runtimeValue = true;
        activeStatus = true;
        thisDoor.OpenDoor();
        mySprite.sprite = onSprite;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger && !activeStatus)
        {
            ActivateSwitch();
        }
    }

}
