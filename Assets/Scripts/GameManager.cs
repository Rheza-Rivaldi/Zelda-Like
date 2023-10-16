using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public List<ScriptableObject> objects = new List<ScriptableObject>();

    private void OnEnable() {
        LoadData();
    }
    private void OnDisable() {
        SaveData();
    }

    void Awake() {
        if(gameManager == null){
            gameManager = this;
        }  
        else{
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this); 
    }

    void SaveData(){
        for(int i = 0; i < objects.Count; i++){
            FileStream file = File.Create(Application.dataPath + string.Format("/{0}.dat", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    void LoadData(){
        for(int i = 0; i < objects.Count; i++){
            if(File.Exists(Application.dataPath + string.Format("/{0}.dat", i))){
                FileStream file = File.Open(Application.dataPath + string.Format("/{0}.dat", i),FileMode.Open); 
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);
                file.Close();
            }
        }
    }
}
