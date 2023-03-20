using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Log
{
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentState = enemyState.idle;
        myRigidBody = GetComponent<Rigidbody2D>();
        originalPosition = this.transform.position;
        target = GameObject.FindWithTag("Player").transform;
        anim.SetBool("moving", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    public override void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if(currentState == enemyState.idle || currentState == enemyState.walk && currentState != enemyState.stagger){
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                changeAnim(temp - transform.position);
                anim.SetBool("moving", true);
                myRigidBody.MovePosition(temp);
                ChangeState(enemyState.walk);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) <= attackRadius){
            if(currentState != enemyState.attack && currentState != enemyState.stagger){
                StartCoroutine(AttackAnim());
            }
        }
        else if (currentState != enemyState.idle && transform.position != originalPosition)
        {
            if(currentState == enemyState.idle || currentState == enemyState.walk && currentState != enemyState.stagger){
                Vector3 temp = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.fixedDeltaTime);
                changeAnim(temp - transform.position);
                anim.SetBool("moving", true);
                myRigidBody.MovePosition(temp);
                ChangeState(enemyState.walk);
            }
        }
        else if (transform.position == originalPosition)
        {
            ChangeState(enemyState.idle);
            anim.SetBool("moving", false);
        }
    }

    private IEnumerator AttackAnim(){
        anim.SetBool("attack", true);
        ChangeState(enemyState.attack);
        yield return null;
        anim.SetBool("attack", false);
        yield return new WaitForSeconds(1f);
        ChangeState(enemyState.idle);
    }
}
