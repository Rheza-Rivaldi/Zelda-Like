using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum PlayerState{
        idle,
        walk,
        attack,
        interact,
        stagger
    }
    public PlayerState currentState;

    public Inventory playerInventory;
    public SpriteRenderer obtainedItemSprite;

    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    /* public FloatValue currentHealth;
    public Signal playerHealthSignal; */
    
    public Signal shakeScreen;

    public GameObject projectile;
    public Item bow;
    public Signal useMP;

    public VectorValue startingPosition;

    [Header("Iframe")]
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.idle;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", 1);
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == PlayerState.interact){
            return;
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger){
            StartCoroutine(AttackAnim());
        }
        else if(Input.GetButtonDown("Projectile") && currentState != PlayerState.attack && currentState != PlayerState.stagger && playerInventory.currentMP > 0){
            if(playerInventory.CheckForItem(bow)){
                StartCoroutine(ProjectileAnim());
            }
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
        yield return new WaitForSeconds(0.3f);
        if(currentState != PlayerState.interact){
            currentState = PlayerState.idle;
        }
    }

    private IEnumerator ProjectileAnim(){
        //animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        MakeArrow();
        //animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.4f);
        if(currentState != PlayerState.interact){
            currentState = PlayerState.idle;
        }
    }

    void MakeArrow(){
        Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.Setup(temp, ArrowDirection());
        playerInventory.MPUsage(arrow.mPCost);
        useMP.RaiseSignal();
    }

    Vector3 ArrowDirection(){
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0,0, temp);
    }

    public void RaiseItem(){
        if(playerInventory.currentItem != null){
            if(currentState != PlayerState.interact){
                animator.SetBool("ObtainItem", true);
                currentState = PlayerState.interact;
                obtainedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else{
                animator.SetBool("ObtainItem", false);
                currentState = PlayerState.idle;
                obtainedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }

    void UpdateAnimationAndMove(){
        if(change!=Vector3.zero)
        {
            MoveCharacter();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
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
        myRigidbody.MovePosition (transform.position + change * speed * Time.fixedDeltaTime);
    }

    public void KnockPlayer(float knockbackDuration){
        StartCoroutine(DoKnockback(knockbackDuration));
        
        /* currentHealth.RuntimeValue -= damage;
        playerHealthSignal.RaiseSignal();
        if(currentHealth.RuntimeValue > 0){
            StartCoroutine(DoKnockback(knockbackDuration));
        }
        else if(currentHealth.RuntimeValue <= 0){
            playerHealthSignal.RaiseSignal();
            this.gameObject.SetActive(false);
        } */
    }

    private IEnumerator DoKnockback(float knockbackDuration){
        shakeScreen.RaiseSignal();
        if(myRigidbody != null){
            StartCoroutine(DoFlashes());
            yield return new WaitForSeconds(knockbackDuration);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
        }
    }

    private IEnumerator DoFlashes(){
        int temp = 0;
        triggerCollider.enabled = false;
        while(temp < numberOfFlashes){
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        triggerCollider.enabled = true;
    }
}
