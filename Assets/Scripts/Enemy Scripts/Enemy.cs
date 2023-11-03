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
    public LootTable thisLoot;
    
    private void Awake() {
        health = maxHealth.initialValue;
    }

    private void OnEnable() {
        transform.position = originalPosition;
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            if(deathSignal != null){
                deathSignal.RaiseSignal();
            }
            DeathAnim();
            MakeLoot();
            this.gameObject.SetActive(false);
        }
    }

    void MakeLoot(){
        if(thisLoot.loots != null){
            PowerUp current = thisLoot.dropLoots();
            if(current != null){
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    void DeathAnim(){
        if(deathAnimPrefab != null){
            GameObject effect = Instantiate(deathAnimPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

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
