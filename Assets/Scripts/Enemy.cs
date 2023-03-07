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

    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    
    private void Awake() {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            this.gameObject.SetActive(false);
        }
    }

    public void KnockEnemy(Rigidbody2D myRigidbody, float knockbackDuration, float damage){
        StartCoroutine(DoKnockback(myRigidbody, knockbackDuration));
        TakeDamage(damage);
    }

    private IEnumerator DoKnockback(Rigidbody2D myRigidbody, float knockbackDuration){
        if(myRigidbody != null){
            yield return new WaitForSeconds(knockbackDuration);
            myRigidbody.velocity = Vector2.zero;
            currentState = enemyState.idle;
        }
    }
}
