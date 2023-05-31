using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class saveScenes : MonoBehaviour
{
    public GameObject canvasSave;
    public GameObject canvasOverwrite;

    //variables
    int intToSave;
    float floatToSave;
    bool boolToSave;

    //Serialización es el proceso automático de transformar datos para que Unity los pueda guardar y reconstruir más tarde.
    //Esta clase va a almacenar los datos de la partida que se vayan a guardar en el momento.
    //Los valores de las variables de SaveSerial se pasan a SaveData y serializan esta clase
    [Serializable]
    class SaveData
    {
    public int savedInt;
    public float savedFloat;
    public bool savedBool;}


    // Start is called before the first frame update
    void Start()
    {
        canvasSave.SetActive(false);
        canvasOverwrite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Guardar partida
    //BinaryFormatter serializa y deserializa
    //FileStream y File crean el archivo de guardado
    public void SaveGame()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            //Si ya hay al menos un registro de guardado
            if (File.Exists(Application.persistentDataPath 
                        + "/MySaveData.dat"))
                canvasOverwrite.SetActive(true);
                    //le damos que si a sobreescribir:          
                        /*{
                            canvasOverwrite.SetActive(false)
                            BinaryFormatter bf = new BinaryFormatter();
                            FileStream file = 
                                    File.Open(Application.persistentDataPath 
                                    + "/MySaveData.dat", FileMode.Open);
                            SaveData data = (SaveData)bf.Deserialize(file);
                            file.Close();
                            intToSave = data.savedInt;
                            floatToSave = data.savedFloat;
                            boolToSave = data.savedBool;
                            Debug.Log("Game data loaded!");
                            canvasSave.SetActive(true);
                        }*/

                    //Si le damos que no:
                        //canvasOverwrite.SetActive(false);
                    
            //Si no había registro de guardado
            else
            {	BinaryFormatter bf = new BinaryFormatter(); 
                FileStream file = File.Create(Application.persistentDataPath 
                        + "/MySaveData.dat"); 
                SaveData data = new SaveData();
                data.savedInt = intToSave;
                data.savedFloat = floatToSave;
                data.savedBool = boolToSave;
                bf.Serialize(file, data);
                file.Close();
                Debug.Log("Game data saved!");
                canvasSave.SetActive(true);
            }

        }
        
    }

    public void OverWrite(){
        canvasOverwrite.SetActive(true);
    }

    public void Volver(){
        canvasOverwrite.SetActive(false);
        canvasSave.SetActive(false);
    }

}
