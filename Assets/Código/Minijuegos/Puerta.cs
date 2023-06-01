using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a la que quieres ir
    public string Llave; // ID del item necesario (en este caso, la linterna)
    
    private bool playerInRange = false;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (playerInRange && Input.GetMouseButtonDown(0))
        {
            if (Inventario.Instance.TieneItem(Llave))
            {
                SceneManager.LoadScene(nombreEscena);
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


}
