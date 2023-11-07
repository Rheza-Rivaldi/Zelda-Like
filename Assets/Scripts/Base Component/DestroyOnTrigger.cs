using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    [SerializeField]private string targetTag;

    public void OnTriggerEnter2D(Collider2D other) {
        if(!other.isTrigger || other.CompareTag(targetTag)){
            Destroy(this.gameObject);
        }
    }
}
