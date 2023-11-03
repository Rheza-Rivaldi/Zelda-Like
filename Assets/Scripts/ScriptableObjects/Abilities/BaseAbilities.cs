using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Object/Ability", fileName = "New Ability")]
public class BaseAbilities : ScriptableObject
{
    public virtual void Ability(Vector2 playerPosition, Vector2 playerFacing = default(Vector2), Animator playerAnimator = null, Rigidbody2D playerRigidbody = null){

    }
}
