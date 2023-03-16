using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemy : Log
{
    public Collider2D boundary;

    public override void CheckDistance()
    {
        //check if player is inside the boundary
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius && boundary.bounds.Contains(target.transform.position))
        {
            if(currentState == enemyState.idle || currentState == enemyState.walk && currentState != enemyState.stagger){
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
                anim.SetBool("awaken", true);
                ChangeState(enemyState.walk);
            }
        }
        else if (currentState != enemyState.idle && transform.position != originalPosition && !boundary.bounds.Contains(target.transform.position))
        {
            if(currentState == enemyState.idle || currentState == enemyState.walk && currentState != enemyState.stagger){
                Vector3 temp = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.fixedDeltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
                ChangeState(enemyState.walk);
            }
        }
        else if (transform.position == originalPosition)
        {
            if(anim.GetBool("awaken")){
                anim.SetBool("awaken", false);
            }
            ChangeState(enemyState.idle);
        }
    }
}
