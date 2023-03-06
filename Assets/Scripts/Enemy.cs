using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum enemyState{
        idle,
        walk,
        attack,
        stagger
    }
    public enemyState currentState;


    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    
    public void KnockEnemy(Rigidbody2D myRigidbody, float knockbackDuration){
        StartCoroutine(DoKnockback(myRigidbody, knockbackDuration));
    }

    private IEnumerator DoKnockback(Rigidbody2D myRigidbody, float knockbackDuration){
        if(myRigidbody != null){
            yield return new WaitForSeconds(knockbackDuration);
            myRigidbody.velocity = Vector2.zero;
            currentState = enemyState.idle;
        }
    }
}
