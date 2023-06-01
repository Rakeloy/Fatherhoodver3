using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogoManager : Singleton<DialogoManager>

{
   
   [SerializeField] private GameObject panelDialogo;
   [SerializeField] private Image npcIcono;
    [SerializeField] private TextMeshProUGUI npcNombreTMP;
    [SerializeField] private TextMeshProUGUI npcConversacionTMP;
    public NPCInteraccion NPCDisponible { get; set; }
  
  private void Update()
    {
        if (NPCDisponible == null)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            ConfigurarPanel(NPCDisponible.Dialogo);
        }
    }
     public void AbrirCerrarPanelDialogo(bool estado)
    {
        panelDialogo.SetActive(estado);
    }
    private void ConfigurarPanel(NPCDialogo npcDialogo)
    {
        AbrirCerrarPanelDialogo(true);
         npcIcono.sprite = npcDialogo.Icono;
        npcNombreTMP.text = $"{npcDialogo.Nombre}:";
       
    }
    
    
}
