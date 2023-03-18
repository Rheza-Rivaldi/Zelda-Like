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
    public Vector3 originalPosition;

    public GameObject deathAnimPrefab;
    public Signal deathSignal;
    
    private void Awake() {
        health = maxHealth.initialValue;
    }

    private void OnEnable() {
        transform.position = originalPosition;
    }

    private void TakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            deathSignal.RaiseSignal();
            DeathAnim();
            this.gameObject.SetActive(false);
        }
    }

    void DeathAnim(){
        if(deathAnimPrefab != null){
            GameObject effect = Instantiate(deathAnimPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
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
