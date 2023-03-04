using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum PlayerState{
        idle,
        walk,
        attack,
        interact
    }
    public PlayerState currentState;

    public float speed;
    private Rigidbody2D myrigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.idle;
        animator = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", 1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Attack") && currentState != PlayerState.attack){
            StartCoroutine(AttackAnim());
        }
        else if(currentState == PlayerState.idle){
            UpdateAnimationAndMove();
        }
    }
    

    private IEnumerator AttackAnim(){
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.4f);
        currentState = PlayerState.idle;
    }

    void UpdateAnimationAndMove(){
        if(change!=Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter(){
        change.Normalize();
        myrigidbody.MovePosition (transform.position + change * speed * Time.fixedDeltaTime);
    }
}
