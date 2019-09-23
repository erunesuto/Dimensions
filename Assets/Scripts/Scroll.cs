using UnityEngine;

public class Scroll : MonoBehaviour
{

   
    public float velocidad = 1f;
    public Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        
        
    }

   
    // Update is called once per frame
    void Update()
    {   
        //modificamos directamente el offset de la textura(posicion/desplazamiento)                                   
        //Time.deltaTime es para hacer el movimiento mas suave.
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(GetComponent<Renderer>().material.mainTextureOffset.x + (rb2d.velocity.x * velocidad * Time.deltaTime), 0);  
    }
    
}
