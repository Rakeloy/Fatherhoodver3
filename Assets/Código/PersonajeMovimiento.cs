using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    private void Awake(){
        _rigibody2D = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
