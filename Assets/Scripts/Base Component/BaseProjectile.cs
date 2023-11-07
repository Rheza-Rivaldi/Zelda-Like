using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{

    [SerializeField]private Rigidbody2D myRigidbody;
    [SerializeField]private float mySpeed;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void ProjectileSetup(Vector2 moveDirection){
        myRigidbody.velocity = moveDirection.normalized * mySpeed;
    }


}
