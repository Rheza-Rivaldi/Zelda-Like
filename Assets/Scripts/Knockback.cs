using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackForce;
    public float knockbackDuration;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            Rigidbody2D enemyRB = other.GetComponent<Rigidbody2D>();
            if(enemyRB != null){
                other.GetComponent<Enemy>().currentState = Enemy.enemyState.stagger;
                Vector2 difference = new Vector2(other.transform.position.x - transform.position.x, other.transform.position.y - transform.position.y);
                difference = difference.normalized * knockbackForce;
                enemyRB.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(DoKnockback(enemyRB));
            }
        }
    }

    private IEnumerator DoKnockback(Rigidbody2D enemy){
        if(enemy != null){
            yield return new WaitForSeconds(knockbackDuration);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = Enemy.enemyState.idle;
        }
    }
}
