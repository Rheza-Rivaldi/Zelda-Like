using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{
    public Door[] doors;
    public int enemyCounter;



    public void CheckEnemies(){
        --enemyCounter;
        if(enemyCounter == 0){
            OpenDoors();
        }
        
        
    }

    public override void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            //activate all gameobjects
            for(int i = 0; i < enemies.Length; i++){
                ChangeActivation(enemies[i], true);
            }

            for(int i = 0; i < pots.Length; i++){
                ChangeActivation(pots[i], true);
            }

            CloseDoors();
            enemyCounter = enemies.Length;
        }
        
    }

    /* public override void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            //deactivate all gameobjects
            for(int i = 0; i < enemies.Length; i++){
                ChangeActivation(enemies[i], false);
            }

            for(int i = 0; i < pots.Length; i++){
                ChangeActivation(pots[i], false);
            }
        }
    } */

    /* public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        CloseDoors();
        enemyCounter = enemies.Length;
    } */

    public void CloseDoors(){
        for(int i = 0; i < doors.Length; i++){
            doors[i].CloseDoor();
        }
    }

    public void OpenDoors(){
        for(int i = 0; i < doors.Length; i++){
            doors[i].OpenDoor();
        }
    }


}
