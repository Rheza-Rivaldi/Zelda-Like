using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private bool isPaused;
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    [SerializeField] private bool pausing;
    [SerializeField] private bool openingInventory;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pausing = false;
        openingInventory = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause")){
            pausing = !pausing;
            openingInventory = false;
            PauseState();
        }
        if(Input.GetButtonDown("Inventory")){
            openingInventory = !openingInventory;
            pausing = false;
            PauseState();
        }
    }

    public void PauseState(){
        if(pausing || openingInventory){
            isPaused = true;
        }else{
            isPaused = false;
        }
        pausePanel.SetActive(pausing);
        inventoryPanel.SetActive(openingInventory);
        if(isPaused){
            Time.timeScale = 0f;
        }
        else{
            Time.timeScale = 1f;
        }
    }
    public void Quit(){
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1f;
    }

}
