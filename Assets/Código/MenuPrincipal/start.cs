using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class start : MonoBehaviour
{
    public GameObject canvasStart;
    public GameObject canvasCredits;
    public GameObject canvasNoload;
    public GameObject canvasControles;
    public GameObject canvasSave;
    public GameObject canvasOverwrite;

    //variables
    int intToSave;
    float floatToSave;
    bool boolToSave;

    [Serializable]
    class SaveData
    {
        public int savedInt;
        public float savedFloat;
        public bool savedBool;
    }

    // Start is called before the first frame update
    void Start()
    {
        canvasStart.SetActive(true);
        canvasCredits.SetActive(false);
        canvasNoload.SetActive(false);
        canvasControles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EntrarJuego(){
        SceneManager.LoadScene("New Scene");
    }

    public void EntrarCredits(){
        canvasStart.SetActive(false);
        canvasCredits.SetActive(true);
    }

    public void EntrarControles(){
        canvasStart.SetActive(false);
        canvasControles.SetActive(true);
    }

    public void VolverStart(){
        canvasStart.SetActive(true);
        canvasCredits.SetActive(false);
        canvasNoload.SetActive(false);
        canvasControles.SetActive(false);
    }

    public void SalirJuego(){
        Debug.Log("Salir");
        Application.Quit();
    }

    public void CargarPartida()
    {
	if (File.Exists(Application.persistentDataPath 
                  + "/MySaveData.dat"))
	{
	}
	else
        canvasNoload.SetActive(true);
    }

    //canvas escenas

    /*void Guardar(){
        if(Input.GetKeyDown(KeyCode.G)){
            //Si ya hay al menos un registro de guardado
            if (File.Exists(Application.persistentDataPath 
                        + "/MySaveData.dat")){
                canvasOverwrite.SetActive(true);
                        }
            else
            {
            canvasOverwrite.SetActive(false);
            canvasSave.SetActive(true);
                }
        }
    }*/
        
        
}
