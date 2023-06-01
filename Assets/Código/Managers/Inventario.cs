using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Inventario : MonoBehaviour
{
    public GameObject[] slots;
    Text text;
    private int num_slots_max = 5;
    public static GameObject scriptDuplicado;
    public GameObject Amiga;
     void Awake(){
        DontDestroyOnLoad(this.gameObject);
        if(scriptDuplicado == null){
            scriptDuplicado = this.gameObject;
        }else if(scriptDuplicado != null){ 
            Destroy(this.gameObject);
        }
     }


    // Start is called before the first frame update
    void Start()
    {
        slots = new GameObject[num_slots_max];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject[] getSlots(){
        return this.slots;
    }
    public void setSlot(GameObject slot, int pos,int cant){
        bool exit = false;
        for (int i=0; i< slots.Length;i++){
            if (slots[i] != null)
            //botella == botella?
            {
                if (slots[i].tag == slot.tag){
                    int already_cant = slots[i].GetComponent<AtributosControlador>().getCantidad();
                    this.slots[i].GetComponent<AtributosControlador>().setCantidad(already_cant + cant);
                    exit =true;
                }
            }
        }
        if (!exit){
           slot.GetComponent<AtributosControlador>().setCantidad(cant);
            this.slots[pos] =slot;
        }
    }
    public void showInventory(){
    Component[] inventario = GameObject.FindGameObjectWithTag("inventario").GetComponentsInChildren<Transform>();
    bool slotUsed = false;
    if (removeItems(inventario)){
        for (int i = 0; i< slots.Length;i++){
            if (slots[i] != null){
                slotUsed = false;
                for (int e = 0; e < inventario.Length;e++){
                    GameObject child = inventario[e].gameObject;

                    if(child.tag == "slot" && child.transform.childCount <= 1 && !slotUsed)
                    {
                        GameObject item = Instantiate(slots[i],child.transform.position,Quaternion.identity);
                        item.transform.SetParent(child.transform,false);
                        item.transform.localPosition =new Vector3(0,0,0);
                        item.name = item.name.Replace("Clone", "");
                        text = slots[i].GetComponentInChildren<Text>();
                        int cant = 1;
                        text.text =cant + "";

                        slotUsed =true;

                    }
                }
            }
        }
    }
    }
    
    public bool removeItems(Component[] inventario) {
        for (int e = 1; e < inventario.Length ; e++){
            GameObject child = inventario[e].gameObject;
            if (child.tag =="slot" && child.transform.childCount >0){
                for (int a = 0; a<=0;a++){
                    Destroy(child.transform.GetChild(a).transform.gameObject);
                }
            }

        }
        //Funcion de borrado 
        return true;
    }
    public void DropItemOnAmiga(GameObject item)
{
    // Comprueba si el objeto está en los slots del inventario
    for (int i = 0; i < slots.Length; i++)
    {
        if (slots[i] != null && slots[i] == item)
        {
            // Suelta el objeto en el NPC
            item.transform.SetParent(Amiga.transform, false);
            item.transform.localPosition = Vector3.zero;
            slots[i] = null;

            // Llama al método ReceiveItem del NPCReceptor
            AmigaReceptor AmigaReceptor = Amiga.GetComponent<AmigaReceptor>();
            if (AmigaReceptor != null)
            {
                AmigaReceptor.ReceiveItem(item);
            }
// Verifica si se han entregado los 5 objetos
            bool allItemsDelivered = true;
            for (int j = 0; j < slots.Length; j++)
            {
                if (slots[j] != null)
                {
                    allItemsDelivered = false;
                    break;
                }
            }

            // Si se han entregado los 5 objetos, activa la escena CuartoPadre
            if (allItemsDelivered)
            {
                // Carga la escena CuartoPadre
                SceneManager.LoadScene("CuartoPadre");
            }

            break;
        }
    }
}
}