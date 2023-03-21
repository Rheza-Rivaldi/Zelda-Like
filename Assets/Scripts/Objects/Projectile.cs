using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 directionToMove;
    public float lifetime;
    public float lifetimeSeconds;
    public Rigidbody2D myRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        lifetimeSeconds = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        lifetimeSeconds -= Time.deltaTime;
        if(lifetimeSeconds <= 0){
            Destroy(this.gameObject);
        }
    }

    public void Launch(Vector2 target){
        myRigidbody.velocity = target * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(!other.isTrigger || other.CompareTag("Player")){
            Destroy(this.gameObject);
        }
    }

    public void OnBecameInvisible() {
        Destroy(this.gameObject, 1f);
    }
}
