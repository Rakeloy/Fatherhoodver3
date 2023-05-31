using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaCama : MonoBehaviour
{
    public string Cama; // Nombre de la escena a la que quieres ir
    public string Linterna; // ID del item necesario (en este caso, la linterna)
    public GameObject panelMensaje;
     private void Start(){
        panelMensaje.SetActive(false);
     }


    private void OnMouseDown()
    {
       if (Inventario.Instance.TieneItem(Linterna)){
        SceneManager.LoadScene(Cama);
       }else
        {
            // Mostrar el panel de mensaje indicando que se requiere el item
            panelMensaje.SetActive(true);
            Invoke("DesactivarPanelMensaje", 2f);
        }
    }
    private void DesactivarPanelMensaje()
    {
        panelMensaje.SetActive(false);
    }
}