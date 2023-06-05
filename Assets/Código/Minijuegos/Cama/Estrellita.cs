using UnityEngine;
using UnityEngine.SceneManagement;

public class Estrellita : MonoBehaviour
{
    public InventarioItem ItemPaloGancho;
    public int cantidad = 1;
    public float tiempoEspera = 2f;
    public string PrincipalSceneName;


    private void OnMouseDown()
    {
       if (Inventario.Instance != null)
       {
            // Añadir el objeto al inventario
            Inventario.Instance.AñadirItem(ItemPaloGancho, cantidad);
        }

        // Desactivar la estrellita
        gameObject.SetActive(false);

        // Esperar un tiempo y luego cambiar de escena
        Invoke("CambiarEscena", tiempoEspera);
    }

    private void CambiarEscena()
    {
        SceneManager.LoadScene("New Scene");
    }
}


