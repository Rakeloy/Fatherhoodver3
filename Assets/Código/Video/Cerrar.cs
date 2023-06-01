using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cerrar : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nombreEscena;

    private void Start()
    {
        // Suscribirse al evento loopPointReached del VideoPlayer
        videoPlayer.loopPointReached += CambiarAEscenaMenuPrincipal;
    }

    private void CambiarAEscenaMenuPrincipal(VideoPlayer source)
    {
        // Cambiar a la escena del menú principal
        SceneManager.LoadScene(nombreEscena);
    }
}
