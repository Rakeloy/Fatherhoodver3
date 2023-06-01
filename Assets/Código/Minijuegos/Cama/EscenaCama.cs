using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaCama : MonoBehaviour
{
    public string Cama; // Nombre de la escena a la que quieres ir
    public string Linterna; // ID del item necesario (en este caso, la linterna)
    public GameObject panelMensaje;
    private bool playerInRange = false;

    private void Start()
    {
        panelMensaje.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetMouseButtonDown(0))
        {
            if (Inventario.Instance.TieneItem(Linterna))
            {
                SceneManager.LoadScene(Cama);
            }
            else
            {
                // Mostrar el panel de mensaje indicando que se requiere el item
                panelMensaje.SetActive(true);
                Invoke("DesactivarPanelMensaje", 2f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void DesactivarPanelMensaje()
    {
        panelMensaje.SetActive(false);
    }
}
