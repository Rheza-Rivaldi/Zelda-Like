using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    /* public FloatValue playerHealth;
    public FloatValue heartContainer; */
    //[SerializeField]private PlayerHealth playerHealth;
    [SerializeField]private float healthValue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && other.isTrigger){
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if(playerHealth.currentHealth < playerHealth.healthContainer.RuntimeValue *2f){
                playerHealth.IncreaseHealthPoint(healthValue);
                powerUpSignal.RaiseSignal();
                Destroy(this.gameObject);
            }
        }
    }
}
