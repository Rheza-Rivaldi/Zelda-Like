using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackForce;
    public float knockbackDuration;

    private void Update() {
        if(this.gameObject.activeInHierarchy && this.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TurnAttackOff());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Breakable") && this.gameObject.CompareTag("Player")){
            other.GetComponent<Pot>().Smash();
        }
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player")){
            Rigidbody2D targetRB = other.GetComponent<Rigidbody2D>();
            if(targetRB != null){
                Vector2 difference = new Vector2(other.transform.position.x - transform.position.x, other.transform.position.y - transform.position.y);
                difference = difference.normalized * knockbackForce;
                targetRB.AddForce(difference, ForceMode2D.Impulse);

                if(other.gameObject.CompareTag("Enemy")){
                    other.GetComponent<Enemy>().currentState = Enemy.enemyState.stagger;
                    other.GetComponent<Enemy>().KnockEnemy(targetRB, knockbackDuration);
                }
                if(other.gameObject.CompareTag("Player")){
                    other.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.stagger;
                    other.GetComponent<PlayerMovement>().KnockPlayer(knockbackDuration);
                }
                
            }
        }
    }

    private IEnumerator TurnAttackOff(){
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
