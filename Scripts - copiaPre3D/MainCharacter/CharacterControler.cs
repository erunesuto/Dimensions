using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{

    public float velocidad = 10f;
    public float velocidadMaxima = 5f;
    public bool enSuelo;
    public float fuerzaSalto = 5f;
    public int restarPositionX = 0;// para resetear la posicion fase pruebas



    //public Transform personaje;
    private Rigidbody rb;
    // private Animator anim;



    // Use this for initialization
    void Start()
    {
        // la variable rb2d hace referencia al rigidbody del objeto al que asignamos el script(inspector)
        rb = GetComponent<Rigidbody>();
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

        //pisoton
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -(fuerzaSalto * 10));
            if (enSuelo == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -(fuerzaSalto * 4));
            }
        }

        //Reinicia la posicion del personaje
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = new Vector3(restarPositionX, 10, 0);
            //personaje.position.x
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
        rb.AddForce(Vector2.right * velocidad * horizontal);

        //lIMITA LA VELOCIDAD
        //Mathf agrupa un conjuto de funciones matematicas
        //Clamp limita un VALOR entre un MAXIMO y un MINIMO. En este caso la velocidad.
        //float velocidadLimite = Mathf.Clamp(valorALimitar, -valorMinimo, valorMaximo);
        float velocidadLimite = Mathf.Clamp(rb.velocity.x, -velocidadMaxima, velocidadMaxima);
        rb.velocity = new Vector2(velocidadLimite, rb.velocity.y);


        //MODIFICAR ORIENTACION AL MOVERSE
        //Si la velocidad es superior a 0 se cambia la orientacion(en realidad es la escala) en el ejeX a la derecha "1"
        //modifica transform.scale en el hierachy de -1 a 1
        if (horizontal > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        //Si la velocidad es inferior a 0 se cambia la orientacion en el ejeX a la izquierda "-1"
        if (horizontal < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


        //Debug.Log("rb2d.velocity.x " + rb2d.velocity.x + "|velocidad "+ velocidad);
    }


}