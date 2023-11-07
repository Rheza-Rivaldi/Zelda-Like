using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Multi Projectile Ability", fileName = "New Multi Projectile Ability")]
public class MultiProjectileAbility : BaseAbilities
{
    [SerializeField]private GameObject thisProjectile;
    [SerializeField]private int numberOfProjectile;
    [SerializeField]private float projectileSpread;


    public override void Ability(Vector2 playerPosition, Vector2 playerFacing = default, Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {
        //base.Ability(playerPosition, playerFacing, playerAnimator, playerRigidbody);
        if(playerMP.RuntimeValue >= mPCost){
            playerMP.RuntimeValue -= mPCost;
            mPSignal.RaiseSignal();
        }
        else{return;}
        
        float facingRotation = Mathf.Atan2(playerFacing.y, playerFacing.x) * Mathf.Rad2Deg;
        float startRotation = facingRotation + projectileSpread / 2f;
        float angleIncrease = projectileSpread / ((float)numberOfProjectile - 1f);

        for(int i = 0; i < numberOfProjectile; i++){
            float tempAngle = startRotation - angleIncrease * i;
            GameObject newProjectile = Instantiate(thisProjectile, playerPosition, Quaternion.Euler(0f,0f, tempAngle));
            BaseProjectile temp = newProjectile.GetComponent<BaseProjectile>();
            if(temp != null){
                temp.ProjectileSetup(new Vector2(Mathf.Cos(tempAngle * Mathf.Deg2Rad), Mathf.Sin(tempAngle * Mathf.Deg2Rad)));
            }
        }
    }
}
