using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause")){
            PauseState();
        }
    }

    public void PauseState(){
        isPaused = !isPaused;
            pausePanel.SetActive(isPaused);
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
