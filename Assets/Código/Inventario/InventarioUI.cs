using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioUI : MonoBehaviour{
   
    [SerializeField] private InventarioSlot slotPrefab;
    [SerializeField] private Transform contenedor;

    public static InventarioUI Instance { get; private set; }

    public static GameObject scriptDuplicadoUI;


    private List<InventarioSlot> slotsDisponibles = new List<InventarioSlot>();
   
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        DontDestroyOnLoad(this.gameObject);

        if(scriptDuplicadoUI == null){
            scriptDuplicadoUI = this.gameObject;
        }else if(scriptDuplicadoUI != null){ 
            Destroy(this.gameObject);
        };

        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 

    }
    // Start is called before the first frame update
    void Start()
    {
        InicializarInventario();
    }

    public void InicializarInventario()
    {
        for (int i = 0; i < Inventario.Instance.NumeroDeSlots; i++)
        {
            InventarioSlot nuevoSlot = Instantiate(slotPrefab, contenedor);
            nuevoSlot.Index = i;
            slotsDisponibles.Add(nuevoSlot);
        }
    }
    // Update is called once per frame
    public void DibujarItemEnInventario(InventarioItem itemPorAñadir, int cantidad, int itemIndex)
    {
        InventarioSlot slot = slotsDisponibles[itemIndex];
        if (itemPorAñadir != null)
        {
            slot.ActivarSlotUI(true);
            slot.ActualizarSlot(itemPorAñadir, cantidad);
        }
        else
        {
            slot.ActivarSlotUI(false);
        }
    }
}
