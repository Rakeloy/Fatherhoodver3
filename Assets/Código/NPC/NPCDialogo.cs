using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NPCDialogo : MonoBehaviour
{
    
    [Header("Info")] 
    public string Nombre;
    public Sprite Icono;

    [Header("Saludo")] 
    [TextArea] public string Saludo;

    [Header("Chat")] 
    public DialogoTexto[] Conversacion;
    
    [Header("Despedida")] 
    [TextArea] public string Despedida;

    
}
[Serializable]
public class DialogoTexto{
    [TextArea] public string Oracion;
}