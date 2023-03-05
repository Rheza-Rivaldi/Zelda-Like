using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    private Rigidbody2D myRigidBody;
    public Transform target;
    public Vector3 originalPosition;
    public float chaseRadius;
    public float attackRadius;


    // Start is called before the first frame update
    void Start()
    {
        currentState = enemyState.idle;
        myRigidBody = GetComponent<Rigidbody2D>();
        originalPosition = this.transform.position;
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if(currentState == enemyState.idle || currentState == enemyState.walk && currentState != enemyState.stagger){
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                myRigidBody.MovePosition(temp);
                ChangeState(enemyState.walk);
            }
        }
        else if (currentState != enemyState.idle && transform.position != originalPosition)
        {
            if(currentState == enemyState.idle || currentState == enemyState.walk && currentState != enemyState.stagger){
                Vector3 temp = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.fixedDeltaTime);
                myRigidBody.MovePosition(temp);
                ChangeState(enemyState.walk);
            }
        }
        else if (transform.position == originalPosition)
        {
            ChangeState(enemyState.idle);
        }
    }

    void ChangeState(enemyState newState){
        if(currentState != newState){
            currentState = newState;
        }
    }
}
