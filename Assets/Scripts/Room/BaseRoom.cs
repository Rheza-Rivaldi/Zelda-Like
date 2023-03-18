using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRoom : MonoBehaviour
{
    public Enemy[] enemies;
    public Pot[] pots;

    public virtual void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            //activate all gameobjects
            for(int i = 0; i < enemies.Length; i++){
                ChangeActivation(enemies[i], true);
            }

            for(int i = 0; i < pots.Length; i++){
                ChangeActivation(pots[i], true);
            }
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            //deactivate all gameobjects
            for(int i = 0; i < enemies.Length; i++){
                ChangeActivation(enemies[i], false);
            }

            for(int i = 0; i < pots.Length; i++){
                ChangeActivation(pots[i], false);
            }
        }
    }

    public void ChangeActivation(Component component, bool activation){
        component.gameObject.SetActive(activation);
    }
}
