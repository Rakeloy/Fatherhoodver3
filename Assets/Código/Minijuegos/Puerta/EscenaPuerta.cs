using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaPuerta : MonoBehaviour
{
    public string Puerta; // Nombre de la escena a la que quieres ir
    public string PaloGancho;
    public GameObject panelMensaje;
     private void Start(){
        panelMensaje.SetActive(false);
     }
    private void OnMouseDown()
    {
        if (Inventario.Instance.TieneItem(PaloGancho)){
        SceneManager.LoadScene(Puerta);
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
