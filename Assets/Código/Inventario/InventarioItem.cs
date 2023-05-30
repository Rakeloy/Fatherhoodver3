using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TiposDeItems
{
Carta,
Botella,
Funda,
Mechero,
Uniforme,
Yoyo,
Fotos,
Gancho,
Palo,
PaloGancho,
Llave,
Espejo,
Linterna
}
public class InventarioItem : ScriptableObject
{
    [Header("Parametros")]
    public string ID;
    public string Nombre;
    public Sprite Iconos;


    [Header("Parametros")]
    public TiposDeItems Tipo;
    public bool EsConsumible;
    public bool EsAcumulable;

    [HideInInspector] public int Cantidad;
}
