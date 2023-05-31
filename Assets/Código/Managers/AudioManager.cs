using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip temaPrincipal;
    public AudioClip temaCasa;
    public AudioClip abrirPuerta;
    public AudioClip clicMenu;
    public AudioClip clicGuardado; 
    public AudioClip crujidoPuerta;
    public AudioClip golpesPuerta;
    public AudioClip caminarMadera; 
    public AudioClip caminarHierba; 
    public AudioClip desplazarInterfaz; 
    public AudioClip cristalesPeques; 
    
    
    private AudioSource hiloMusical;
    private AudioSource bgmCasa;

    public static GameObject scriptDuplicado;

    private Scene escenaActual;

     void Awake(){
        DontDestroyOnLoad(this.gameObject);
        //si este objeto existe, destruyete!

        if(scriptDuplicado == null){
            scriptDuplicado = this.gameObject;
        }else if(scriptDuplicado != null){ //"!"?
            Destroy(this.gameObject);
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        hiloMusical = GetComponent<AudioSource>();
        hiloMusical.clip = temaPrincipal;
        //bgmCasa.clip = temaCasa;
        hiloMusical.loop = true;
        hiloMusical.Play();

         /*if(escenaActual.name == "Pasillo"){
            hiloMusical = GetComponent<AudioSource>();
            hiloMusical.clip = temaCasa;
            hiloMusical.Play();
         }*/
    }

    // Update is called once per frame
    void Update()
    {
        // Que suene algo en función de la escena

        

    }

    /*public void ChangeMusic()
    {
        // Que suene algo en función de la escena

        escenaActual = SceneManager.GetActiveScene();
        
        if(escenaActual.name == "MenuPrincipal"){
            //hiloMusical.pitch = 1;



        }else if(escenaActual.name == "Pasillo02"){
            
            hiloMusical.clip = temaCasa;
            hiloMusical.Play();
        }
    }*/

     public void clicBoton(){
        //que suene el clic del boton
        //Debug.Log("Suena");
        hiloMusical.PlayOneShot(clicMenu, 1f);
    }

    public void escenaPasillo(){
 
            hiloMusical = GetComponent<AudioSource>();
            hiloMusical.clip = temaCasa;
            hiloMusical.loop = true;
            hiloMusical.Play();
    
    }

    public void guardarPartida(){
        //hiloMusical.PlayOneShot(sonidoMuerte, 1f);
    }

    public void sonidoPuntos(){
        //hiloMusical.PlayOneShot(sonidoGoal, 1f);
    }
}
