using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class Guardado : MonoBehaviour
{

public GameObject canvasNoload;

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



public void NewGame()
{
    //Si ya existe partida
    if (File.Exists(Application.persistentDataPath 
                  + "/MySaveData.dat"))
        //elcanvasdelmensaje.SetActive(true);
        //Hay que hacer un canvas con un mensaje rollo "¿Seguro que quieres sobreescribir la partida/comenzar una nueva partida?"
        //Seguramente haya que poner este script también en este canvas (para configurar botones y que se abra y cierre)
        //Y los respectivos canvas se tendrán que poner en cada escena para que cargue correctamente
                //Si existe partida y le damos que si a sobreescribir:        
                        {
                            File.Delete(Application.persistentDataPath 
                                            + "/MySaveData.dat");
                            intToSave = 0;
                            floatToSave = 0.0f;
                            boolToSave = false;
                            Debug.Log("Data reset complete!");
                            SceneManager.LoadScene("Pasillo");
                        }

                //Si le damos que no:
                //canvas.SetActive(false)

	//Si no existe partida
    else
		SceneManager.LoadScene("New Scene");
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
            //elcanvasdelmensaje.SetActive(true);
                //le damos que si a sobreescribir:          
                    {
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
                    }

                //Si le damos que no:
                    //canvas.SetActive(false)
                
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
        }

    }
	
}

//Cargar partida
public void LoadGame()
{
    //Si hay ya partida
	if (File.Exists(Application.persistentDataPath 
                   + "/MySaveData.dat"))
	{
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
	}

    //Si no hay partida
	else
        //Canvas con mensaje de error .SetActive(true)
        //Botón "OK" ---> canvas.SetActive(false)
		Debug.LogError("There is no save data!");
}

//Borrar partida
public void ResetData()
{
	if (File.Exists(Application.persistentDataPath 
                  + "/MySaveData.dat"))
	{
		File.Delete(Application.persistentDataPath 
                          + "/MySaveData.dat");
		intToSave = 0;
		floatToSave = 0.0f;
		boolToSave = false;
		Debug.Log("Data reset complete!");
	}
	else
        canvasNoload.SetActive(true);
		Debug.LogError("No save data to delete.");
}




    
}
