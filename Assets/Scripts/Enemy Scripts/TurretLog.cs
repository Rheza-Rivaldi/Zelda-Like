using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLog : Log
{
    public GameObject projectile;
    public float fireDelay;
    private float fireDelaySecond;
    public bool canFire = false;



    private void Update() {
        fireDelaySecond -= Time.deltaTime;
        if(fireDelaySecond <= 0){
            canFire = true;
            fireDelaySecond = fireDelay;
        }        
    }


    public override void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius && canFire)
        {
            if(currentState == enemyState.idle || currentState == enemyState.walk && currentState != enemyState.stagger){
                
                Vector3 tempVector = target.transform.position - transform.position;
                GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                current.GetComponent<Projectile>().Launch(tempVector);
                canFire = false;


                anim.SetBool("awaken", true);
                ChangeState(enemyState.walk);
            }
        }
        else if (currentState != enemyState.idle && transform.position != originalPosition)
        {
            if(currentState == enemyState.idle || currentState == enemyState.walk && currentState != enemyState.stagger){
                
                ChangeState(enemyState.walk);
            }
        }
        else if (transform.position == originalPosition)
        {
            if(anim.GetBool("awaken")){
                anim.SetBool("awaken", false);
            }
            ChangeState(enemyState.idle);
        }
    }
}
