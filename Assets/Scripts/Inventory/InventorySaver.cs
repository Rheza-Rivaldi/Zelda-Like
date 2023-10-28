using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
using Leguar.TotalJSON;


public class InventorySaver : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;

    public ItemDatabase ItemDB;

    //SL is our serializable class that contains a representation of the items we want to save - this is a COPY
    private SerializableListString SL = new SerializableListString();


    private void OnEnable()
    {
        //clear the inventory
        playerInventory.myInventory.Clear();
        Debug.Log("Inventory Count = " + playerInventory.myInventory.Count);

        //clear the SL - we don't want anything in there
        SL.serializableList.Clear();
        //Load our save file
        LoadData();
        //re-import our save back into the game world
        ImportSaveData();
    }

    private void OnDisable()
    {
        //clear the SL 
        SL.serializableList.Clear();
        // build our save data from our current game state
        BuildSaveData();
        //save out the save data
        SaveData();
    }

    private void ImportSaveData()
    {
        Debug.Log("Import Save Data " + SL.serializableList.Count);
        //go through the Sl and rebuild the items in the inventory
        for (int i = 0; i < SL.serializableList.Count; i++)
        {
            
            //we will need the name and the count from the save data
            string name = SL.serializableList[i].name;
            int count = SL.serializableList[i].count;


            // we dont save the actual scriptable objects only a reference (NAME) that we then lookup to insert the correct scriptable object
            InventoryItems obj =  ItemDB.GetItem(name);
                 if (obj)
                  {
                    // we have an object to restor - check how many of that item we need and set it 
                    obj.itemHeld = count;

                    // add the object to the inventory
                    playerInventory.myInventory.Add(obj);
                    Debug.Log("Added " + obj.itemName + " count " + count +" to inventory");
                           
                        }
                        else
                        {
                            //should never hit this!
                            Debug.LogError("ITEM DB Not Found: " + SL.serializableList[i].name);
                        }


        }
    }

    private void BuildSaveData()
    {

        //go through the inventory and save out a key value pair of itemName and itemCount
        //then add to the serializablelist
        for (int i = 0; i < playerInventory.myInventory.Count; i++)
        {
            //create a SerialItem and populate it from the inventory

            SerialItem SI = new SerialItem();
            SI.name = playerInventory.myInventory[i].itemName;
            SI.count = playerInventory.myInventory[i].itemHeld;
            
            //add to our SL - 
            SL.serializableList.Add(SI);

            
        }
    }


    private void SaveData()
    {
        //filepath
        string filepath = Application.dataPath + "/newsave.json";

        //create a streamwriter
        StreamWriter sw = new StreamWriter(filepath);

        //use the JSON library to serialize our serializableList into a JSON object
        JSON jsonObject = JSON.Serialize(SL);

        //turn that JSON object into a pretty formatted string
        string json = jsonObject.CreatePrettyString();

        //write to our file
        sw.WriteLine(json);

        //close the file
        sw.Close();
    }


    public void LoadData()
    {

        //filepath
        string filepath = Application.dataPath + "/newsave.json";
        
        if (File.Exists(filepath))
        {
            //read in the file to a string
            string json = File.ReadAllText(filepath);
            //use the JSON library to parse the string
            JSON jsonObject = JSON.ParseString(json);
            //deserialize the JSON object back into our Serializable class
            SL = jsonObject.Deserialize<SerializableListString>();
        }   

    }

   


}