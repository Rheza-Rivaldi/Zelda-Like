using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float speed;
    public float mPCost;
    public float lifetimeCounter;

    // Start is called before the first frame update
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        Timer(lifetimeCounter);
    }

    public void Setup(Vector2 target, Vector3 direction)
    {
        myRigidbody.velocity = target.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(!other.isTrigger || other.CompareTag("Enemy")){
            Destroy(this.gameObject);
        }
    }

    private void Timer(float timeToLife) {
        //Debug.Log("count started");
        Destroy(this.gameObject, timeToLife);
    }
}
