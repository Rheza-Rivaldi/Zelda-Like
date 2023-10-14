using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Sign
{

    private Vector3 moveDirection;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    public Collider2D boundaries;

    private bool isMoving;
    public float moveTime;
    public float waitTime;
    private float moveTimeSeconds;
    private float waitTimeSeconds;


    // Start is called before the first frame update
    void Start()
    {
        moveTimeSeconds = moveTime;
        waitTimeSeconds = waitTime;
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        ChangeDirection();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if(isMoving){
            moveTimeSeconds -= Time.deltaTime;
            if(moveTimeSeconds <= 0){
                moveTimeSeconds = moveTime;
                isMoving = false;
            }
            if(!playerInRange){
                Move();
            }
        }
        else{
            waitTimeSeconds -= Time.deltaTime;
            if(waitTimeSeconds <= 0){
                ChooseNewDirection();
                isMoving = true;
                waitTimeSeconds = waitTime;
            }
        }
        
    }

    void Move(){
        Vector3 temp = myTransform.position + moveDirection * speed * Time.fixedDeltaTime;
        if(boundaries.bounds.Contains(temp)){
            myRigidbody.MovePosition(temp);
        }
        else{
            ChangeDirection();
        }
    }

    void ChangeDirection(){
        int direction = Random.Range(0, 4);
        switch(direction){
            case 0:
            moveDirection = Vector3.right;
            break;

            case 1:
            moveDirection = Vector3.left;
            break;

            case 2:
            moveDirection = Vector3.down;
            break;

            case 3:
            moveDirection = Vector3.up;
            break;

            default:
            break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation(){
        myAnim.SetFloat("MoveX", moveDirection.x);
        myAnim.SetFloat("MoveY", moveDirection.y);
    }

    void ChooseNewDirection(){
        Vector3 temp = moveDirection;
        ChangeDirection();
        int loops = 0;
        while(temp == moveDirection && loops <100){
            loops++;
            ChangeDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        ChooseNewDirection();
    }
}
