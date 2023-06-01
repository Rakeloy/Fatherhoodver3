using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaFinal : MonoBehaviour
{
      public string nombreEscena; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  

    private void OnMouseDown()
    {
        // Cambiar a la escena especificada
        SceneManager.LoadScene(nombreEscena);
    }
}
