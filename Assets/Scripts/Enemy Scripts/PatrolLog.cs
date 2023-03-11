using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{

    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;


    public override void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if(currentState == enemyState.idle || currentState == enemyState.walk && currentState != enemyState.stagger){
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
                anim.SetBool("awaken", true);
                //ChangeState(enemyState.walk);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if(Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance){
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.fixedDeltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
            }
            else{
                ChangeGoal();
            }
        }
        /* else if (transform.position == originalPosition)
        {
            if(Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance){
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.fixedDeltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
            }
            else{
                ChangeGoal();
            }
            
            //if(anim.GetBool("awaken")){
                //anim.SetBool("awaken", false);
            //}
            //ChangeState(enemyState.idle);
        } */
    }

    void ChangeGoal(){
        if(currentPoint == path.Length - 1){
            currentPoint = 0;
            currentGoal = path[currentPoint];
        }
        else{
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
