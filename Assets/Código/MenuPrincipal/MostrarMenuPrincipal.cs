using UnityEngine;
using UnityEngine.SceneManagement;

public class MostrarMenuPrincipal : MonoBehaviour
{
    public string menuPrincipalSceneName;
    public KeyCode teclaActivacion = KeyCode.X;
    private bool menuPrincipalActivo = false;

    private void Update()
    {
        if (Input.GetKeyDown(teclaActivacion))
        {
            if (!menuPrincipalActivo)
            {
                // Cargar la escena del menú principal
                SceneManager.LoadScene(menuPrincipalSceneName, LoadSceneMode.Additive);
                menuPrincipalActivo = true;
            }
            else
            {
                // Descargar la escena del menú principal
                SceneManager.UnloadSceneAsync(menuPrincipalSceneName);
                menuPrincipalActivo = false;
            }
        }
    }
}



