using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[CreateAssetMenu(menuName = "Scriptable Object/Dash Ability", fileName = "New Dash Ability")]
public class DashAbility : BaseAbilities
{
    public float dashForce;


    public override void Ability(Vector2 playerPosition, Vector2 playerFacing = default, Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {
        base.Ability(playerPosition, playerFacing, playerAnimator, playerRigidbody);

        if(playerRigidbody != null){
            Vector3 dashVector = playerRigidbody.transform.position + (Vector3)playerFacing.normalized * dashForce;
            playerRigidbody.DOMove(dashVector, duration);
        }
    }
}
