using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    /* public FloatValue heartContainers;
    public FloatValue playerCurrentHealth; */
    public PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        UpdateHearts();
        //InitHearts();
    }

    public void InitHearts(){
        for(int i = 0; i < playerHealth.healthContainer.RuntimeValue; i++){
            if(i < hearts.Length){
                hearts[i].gameObject.SetActive(true);
                hearts[i].sprite = emptyHeart;
            }
            else{
                playerHealth.healthContainer.RuntimeValue = i;
            }
        }
    }

    public void UpdateHearts(){
        InitHearts();
        if(playerHealth.currentHealth > playerHealth.healthContainer.RuntimeValue*2)
        {
            playerHealth.currentHealth = playerHealth.healthContainer.RuntimeValue*2;
        }
        float tempHealth = playerHealth.currentHealth / 2;
        for(int i = 0; i < playerHealth.currentHealth; i++){
            if(i <= tempHealth-1)
            {
                //full heart
                hearts[i].sprite = fullHeart;
            }
            else if(i >= tempHealth)
            {
                //empty heart
                if(playerHealth.healthContainer.RuntimeValue > i)
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
            else
            {
                //half heart
                hearts[i].sprite = halfHeart;
            }
        }
    }
}


