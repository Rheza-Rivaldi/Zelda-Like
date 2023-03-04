using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Smash(){
        StartCoroutine(breaks());
    }
    
    private IEnumerator breaks(){
        anim.SetBool("smash", true);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }
}
