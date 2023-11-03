using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : BasicHealthSystem
{
    [SerializeField]private Signal healthSignal;
    public FloatValue healthContainer;

    public override void DecreaseHealthPoint(float amountToDecrease)
    {
        base.DecreaseHealthPoint(amountToDecrease);
        healthSignal.RaiseSignal();
    }

    public override void IncreaseHealthPoint(float amountToIncrease)
    {        
        base.IncreaseHealthPoint(amountToIncrease);
    }
}
