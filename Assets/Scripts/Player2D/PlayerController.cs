using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float velocidad = 10f;
    public float velocidadMaxima = 5f;
    public bool grounded;
    public float fuerzaSalto = 5f;

    public int level;//number of the scene. Change public

    public float jumpSpeedFixed;//reduces the speed on AxisX when jumping. Shorter jumps. it does not used.
    public int restarPositionX = 0;// para resetear la posicion fase pruebas
    //public float gravity = -9.8f;

    //public float fallMultiplier = 2.5f;
    //public float lowJumpMultiplier = 2f;

    private Rigidbody2D rb2d;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        // la variable rb2d hace referencia al rigidbody del objeto al que asignamos el script(inspector)
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //Physics2D.gravity = new Vector3(0, gravity, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
        //INPUT KEY
        //Jump
        if (Input.GetButtonDown("Jump"))
        {       
            if (grounded == true)
            {
                //cambiar el getComponent por la variable rb2d declarada arriba aumenta el rendimiento (?)
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
            }

        }

        //pisoton, stomp
        if (Input.GetButtonDown("Stomp"))
        {
            //GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, -(fuerzaSalto * 10));
            if (grounded == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -(fuerzaSalto * 4));
            }

        }

        //attack
        if ( Input.GetButtonDown("Attack"))
        {  
            animator.SetTrigger("Attack");
        }

        //Reinicia la posicion del personaje
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Physics2D.gravity = new Vector3(0, gravity, 0);
            //Debug.Log(Physics2D.gravity.y);
            transform.position = new Vector3(restarPositionX, 10, transform.position.z);
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
        rb2d.AddForce(Vector2.right * velocidad * horizontal); //ForceMovement

        //lIMITA LA VELOCIDAD
        //Mathf agrupa un conjuto de funciones matematicas
        //Clamp limita un VALOR entre un MAXIMO y un MINIMO. En este caso la velocidad.
        //float velocidadLimite = Mathf.Clamp(valorALimitar, -valorMinimo, valorMaximo);
        //float velocidadLimite = Mathf.Clamp(rb2d.velocity.x, -velocidadMaxima, velocidadMaxima); //Only if using rb2d.AddForce
        //rb2d.velocity = new Vector2(velocidadLimite, rb2d.velocity.y); //ForceMovement

        rb2d.velocity = new Vector2(velocidad * horizontal, rb2d.velocity.y);

        //controla que al saltar reduzca la velocidad para que no salte demasiado horizontalmente(no es la mejor opcion)
        //Hacer alguna cosa con lerp() quiza
        if (grounded==true)
        {
            rb2d.velocity = new Vector2(velocidad * horizontal, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(velocidad * horizontal * jumpSpeedFixed, rb2d.velocity.y);
        }
        

        //animator.SetFloat("SpeedX", rb2d.velocity.x);

        if (rb2d.velocity.x != 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
        //MODIFICAR ORIENTACION AL MOVERSE
        //Si la velocidad es superior a 0 se cambia la orientacion(en realidad es la escala) en el ejeX a la derecha "1"
        //modifica transform.scale en el hierachy de -1 a 1
        if (horizontal > 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        //Si la velocidad es inferior a 0 se cambia la orientacion en el ejeX a la izquierda "-1"
        if (horizontal < -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


        //Debug.Log("rb.velocity.x " + rb.velocity.x + "|velocidad "+ velocidad);
    }


}