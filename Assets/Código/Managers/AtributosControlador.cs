using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributosControlador : MonoBehaviour
{
    public static GameObject scriptDuplicado;

      void Awake(){
        DontDestroyOnLoad(this.gameObject);
        if(scriptDuplicado == null){
            scriptDuplicado = this.gameObject;
        }else if(scriptDuplicado != null){ 
            Destroy(this.gameObject);
        }
     }
    public int cantidad;
    public void setCantidad(int cantidad){
        this.cantidad = cantidad;
    }
    public int getCantidad(){
        return this.cantidad;
    }
}
