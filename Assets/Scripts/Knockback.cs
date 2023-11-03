using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackDuration;
    [SerializeField] private string targetTag;
    //public float damage;

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
        if(other.gameObject.CompareTag(targetTag) && other.isTrigger){
            Rigidbody2D targetRB = other.GetComponentInParent<Rigidbody2D>();
            if(targetRB != null){
                Vector3 difference = new Vector2(other.transform.position.x - transform.position.x, other.transform.position.y - transform.position.y);
                difference = difference.normalized * knockbackForce;
                targetRB.transform.DOMove(targetRB.transform.position + difference, knockbackDuration);
                //targetRB.AddForce(difference, ForceMode2D.Impulse);

                if(other.gameObject.CompareTag("Enemy") && other.isTrigger){
                    other.GetComponent<Enemy>().currentState = Enemy.enemyState.stagger;
                    other.GetComponent<Enemy>().KnockEnemy(targetRB, knockbackDuration);
                }
                if(other.gameObject.CompareTag("Player")){
                    if(other.GetComponentInParent<PlayerMovement>().currentState != PlayerMovement.PlayerState.stagger){
                        other.GetComponentInParent<PlayerMovement>().currentState = PlayerMovement.PlayerState.stagger;
                        other.GetComponentInParent<PlayerMovement>().KnockPlayer(knockbackDuration);
                    }
                }
                
            }
        }
    }

    private IEnumerator TurnAttackOff(){
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
