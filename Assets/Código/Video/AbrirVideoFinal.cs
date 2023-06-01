using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbrirVideoFinal : MonoBehaviour
{
     public string Final; // El nombre de la escena que contiene el video

    private void OnMouseDown()
    {
        SceneManager.LoadScene(Final);
    }
}
