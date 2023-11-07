using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Projectile Ability", fileName = "New Projectile Ability")]
public class ProjectileAbility : BaseAbilities
{
    [SerializeField]private GameObject thisProjectile;


    public override void Ability(Vector2 playerPosition, Vector2 playerFacing = default, Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {
        //base.Ability(playerPosition, playerFacing, playerAnimator, playerRigidbody);
        if(playerMP.RuntimeValue >= mPCost){
            playerMP.RuntimeValue -= mPCost;
            mPSignal.RaiseSignal();
        }
        else{return;}
        
        float facingRotation = Mathf.Atan2(playerFacing.y, playerFacing.x) * Mathf.Rad2Deg;
        GameObject newProjectile = Instantiate(thisProjectile, playerPosition, Quaternion.Euler(0f,0f, facingRotation));
        BaseProjectile temp = newProjectile.GetComponent<BaseProjectile>();
        if(temp != null){
            temp.ProjectileSetup(playerFacing);
        }
    }
}
