using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue savePlayerPosition;
    public Vector2 camNewMin;
    public Vector2 camNewMax;
    public VectorValue camMin;
    public VectorValue camMax;

    public GameObject fadeIn;
    public GameObject fadeOut;
    public float fadeWait;

    private void Awake() {
        if(fadeIn != null){
            GameObject panel = Instantiate(fadeIn, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && !other.isTrigger){
            savePlayerPosition.initialValue = playerPosition;
            StartCoroutine(StartFade());
            //SceneManager.LoadScene(sceneToLoad);
        }
    }

    public IEnumerator StartFade(){
        if(fadeOut != null){
            Instantiate(fadeOut, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        ResetCameraBounds();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOperation.isDone){
            yield return null;
        }
    }

    public void ResetCameraBounds(){
        camMax.initialValue = camNewMax;
        camMin.initialValue = camNewMin;
    }
}
