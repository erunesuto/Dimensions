using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJ1Controller : ControladorPJ
{
    /*
    public float velocidad = 10f;
    public float velocidadMaxima = 5f;
    public bool enSuelo;
    //public bool ataqueBasico;
    public float fuerzaSalto = 5f;
    public int vidas = 3;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    */

    //public Transform personaje;
    private Rigidbody2D rb2d;
    // private Animator anim;



    // Use this for initialization
    void Start()
    {
        

        rb2d = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //INPUT KEY
      
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (enSuelo == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -(fuerzaSalto * 10));
            if (enSuelo == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -(fuerzaSalto * 4));
            }
        }

        //MOVIDA AQUI+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - (10 * fuerzaSalto), GetComponent<Rigidbody2D>().velocity.y);

        }
        

        
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown (KeyCode.Joystick1Button5))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(999999999, GetComponent<Rigidbody2D>().velocity.y);

        }
       

        //Reinicia la posicion del personaje
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(0, 12, 0);
            //personaje.position.x
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - (3*fuerzaSalto), GetComponent<Rigidbody2D>().velocity.y);
        }

        if(Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + (3 * fuerzaSalto), GetComponent<Rigidbody2D>().velocity.y);
        }

    }

    private void FixedUpdate()
    {
        //Horizontal: Aplica una fuerza al pulsar las flechas(izda/dereha) o "A" "D"
        //Vertical: Aplica una fuerza  al pulsar las flechas(Arriba/abajo) o "W" "S"
        //float horizontal = Input.GetAxis("EJE EN EL QUE QUIERES USAR VERTICAL/HORIZONTAL");
        //rb2d.AddForce(Vector2.DIRECCION VECTOR * FUERZA * EJE QUE USAMOS);
        //Si le das a la derecha se mueve a la derecha. SI cambias "right" por "left" se moveria a l izquierda

        float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        rb2d.AddForce(Vector2.right * velocidad * horizontal);
       // rb2d.AddForce(Vector2.up * fuerzaSalto * vertical);

        //lIMITA LA VELOCIDAD
        //Mathf agrupa un conjuto de funciones matematicas
        //Clamp limita un VALOR entre un MAXIMO y un MINIMO. En este caso la velocidad.
        //float velocidadLimite = Mathf.Clamp(valorALimitar, -valorMinimo, valorMaximo);
        float velocidadLimite = Mathf.Clamp(rb2d.velocity.x, -velocidadMaxima, velocidadMaxima);
        rb2d.velocity = new Vector2(velocidadLimite, rb2d.velocity.y);


        //MODIFICAR ORIENTACION AL MOVERSE
        //Si la velocidad es superior a 0 se cambia la horientacion(en realidad es la escala) en el ejeX a la derecha "1"
        //modifica transform.scale en el hierachy de -1 a 1
        if (horizontal > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        //Si la velocidad es inferior a 0 se cambia la horientacion en el ejeX a la izquierda "-1"
        if (horizontal < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        //Debug.Log("horizontal= " + horizontal);
        //Debug.Log("rb2d.velocity.x " + rb2d.velocity.x);
    }

    /*public void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
            print("You clicked the button!");

        if (vidas > 0)
        {
            var posRect = Rect(50, 50, texWidth / 5 * lives, texHeight);
            var texRect = Rect(0, 0, 1.0 / 5 * lives, 1.0);
            GUI.DrawTextureWithTexCoords(posRect, tex, texRect);
        }
    }*/

    
}