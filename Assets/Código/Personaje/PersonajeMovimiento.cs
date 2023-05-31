using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;
    public bool EnMovimiento => _direccionMovimiento.magnitude > 0f;
    public Vector2 DireccionMovimiento => _direccionMovimiento;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direccionMovimiento;
    private Vector2 _input;
    private Inventario inventario; // Referencia al componente Inventario
    private void Awake(){
    _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
         inventario = Inventario.Instance; // Obtener la instancia de Inventario
    }
    private void GuardarPosicionPersonaje()
    {
        if (inventario != null)
        {
            Vector3 posicionPersonaje = transform.position;
            inventario.GuardarPosicionPersonaje(posicionPersonaje);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(x:Input.GetAxisRaw("Horizontal"), y:Input.GetAxisRaw("Vertical"));

        //X
        if (_input.x > 0.1f){
            _direccionMovimiento.x = 1f;
        }
        else if (_input.x < 0f){
            _direccionMovimiento.x = -1f;
        }
        else{
            _direccionMovimiento.x = 0f;
        }

        //Y
        if (_input.y > 0.1f){
            _direccionMovimiento.y = 1f;
        }
        else if (_input.y < 0f){
            _direccionMovimiento.y = -1f;
        }
        else{
            _direccionMovimiento.y = 0f;
        }
    }
  
   private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direccionMovimiento * velocidad * Time.fixedDeltaTime);

        // Guardar la posición del personaje en el inventario
        inventario.GuardarPosicionPersonaje(transform.position);

    }
}
