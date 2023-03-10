using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && playerInRange){
            if(!isOpen){
                //open chest
                OpenChest();
            }
            else{
                //chest already opened
                EmptyChest();
            }
        }
    }

    public void OpenChest(){
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDescription;

        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;

        raiseItem.RaiseSignal();
        context.RaiseSignal();

        isOpen = true;
        anim.SetBool("Opened", true);

    }
    public void EmptyChest(){
        dialogBox.SetActive(false);
        raiseItem.RaiseSignal();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.RaiseSignal();
            playerInRange = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.RaiseSignal();
            playerInRange = false;
        }
    }
}
