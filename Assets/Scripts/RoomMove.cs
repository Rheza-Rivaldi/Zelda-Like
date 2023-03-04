using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;

    //for place cards
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text textName;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
        //text = GameObject.Find("PlaceCard");
        textName = text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            if(needText){
                StartCoroutine(showPlaceCard());
            }
        }
    }

    private IEnumerator showPlaceCard()
    {
        textName.text = placeName;
        text.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        text.SetActive(false);
    }

}
