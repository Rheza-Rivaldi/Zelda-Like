using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Rigidbody2D myRigidBody;
    public Transform target;
    public Vector3 originalPosition;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentState = enemyState.idle;
        myRigidBody = GetComponent<Rigidbody2D>();
        originalPosition = this.transform.position;
        target = GameObject.FindWithTag("Player").transform;
        anim.SetBool("awaken", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if(currentState == enemyState.idle || currentState == enemyState.walk && currentState != enemyState.stagger){
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
                anim.SetBool("awaken", true);
                ChangeState(enemyState.walk);
            }
        }
        else if (currentState != enemyState.idle && transform.position != originalPosition)
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

    void SetAnimFloat(Vector2 setVector){
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    public void changeAnim(Vector2 direction){
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
            if(direction.x > 0){
                SetAnimFloat(Vector2.right);
            }
            else if(direction.x < 0){
                SetAnimFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
            if(direction.y > 0){
                SetAnimFloat(Vector2.up);
            }
            else if(direction.y < 0){
                SetAnimFloat(Vector2.down);
            }
        }
    }

    void ChangeState(enemyState newState){
        if(currentState != newState){
            currentState = newState;
        }
    }
}
