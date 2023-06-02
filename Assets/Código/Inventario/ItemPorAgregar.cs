using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPorAgregar : MonoBehaviour
{

    public GameObject gestorSonido;

    void Awake(){
        gestorSonido = GameObject.Find("AudioManager");
    }

      [Header("Config")]
    [SerializeField] private InventarioItem inventarioItemReferencia;
    [SerializeField] private int cantidadPorAgregar;
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
        Inventario.Instance.AñadirItem(inventarioItemReferencia, cantidadPorAgregar);
        Destroy(gameObject);
        gestorSonido.GetComponent<AudioManager>().Logro();
      }
    }
}
