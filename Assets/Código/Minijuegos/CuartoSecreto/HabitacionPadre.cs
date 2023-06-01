using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitacionPadre : MonoBehaviour
{
    private void Start()
    {
        // Verificar si el item llave está en el inventario
        if (Inventario.Instance.TieneItem("Funda"))
        {
            // Hacer el objeto visible
            gameObject.SetActive(true);
        }
        else
        {
            // Mantener el objeto invisible
            gameObject.SetActive(false);
        }
    }
}
