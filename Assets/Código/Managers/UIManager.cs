using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    
     [Header("Paneles")] 
     [SerializeField] private GameObject panelInventario;

    public static UIManager Instance { get; private set; }
    
   
    public static GameObject scriptDuplicadoUImanager;

   
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        DontDestroyOnLoad(this.gameObject);

        if(scriptDuplicadoUImanager == null){
            scriptDuplicadoUImanager = this.gameObject;
        }else if(scriptDuplicadoUImanager != null){ 
            Destroy(this.gameObject);
        };

        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 

    }


    #region Paneles
    public void AbrirCerrarPanelInventario()
    {
        panelInventario.SetActive(!panelInventario.activeSelf);
    }

    #endregion
}
