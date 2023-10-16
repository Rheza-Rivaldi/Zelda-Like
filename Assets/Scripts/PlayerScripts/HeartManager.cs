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
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        UpdateHearts();
        //InitHearts();
    }

    public void InitHearts(){
        for(int i = 0; i < heartContainers.RuntimeValue; i++){
            if(i < hearts.Length){
                hearts[i].gameObject.SetActive(true);
                hearts[i].sprite = emptyHeart;
            }
            else{
                heartContainers.RuntimeValue = i;
            }
        }
    }

    public void UpdateHearts(){
        InitHearts();
        if(playerCurrentHealth.RuntimeValue > heartContainers.RuntimeValue*2)
        {
            playerCurrentHealth.RuntimeValue = heartContainers.RuntimeValue*2;
        }
        float tempHealth = playerCurrentHealth.RuntimeValue / 2;
        for(int i = 0; i < playerCurrentHealth.RuntimeValue; i++){
            if(i <= tempHealth-1)
            {
                //full heart
                hearts[i].sprite = fullHeart;
            }
            else if(i >= tempHealth)
            {
                //empty heart
                if(heartContainers.RuntimeValue > i)
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


