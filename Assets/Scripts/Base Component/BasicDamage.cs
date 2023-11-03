using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class BasicDamage : MonoBehaviour
{
    [SerializeField] private float damageAmount;
    [SerializeField] private string targetTag;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(targetTag) && other.isTrigger){
            BasicHealthSystem temp = other.GetComponent<BasicHealthSystem>();
            if(temp != null){
                temp.DecreaseHealthPoint(damageAmount);
            }
        }
    }
}
