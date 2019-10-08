using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public bool grounded;
    public float jumpForce = 30f;

    // variables Version2
    public float groundSpeed = 20;//groundSpeed
    public float airSpeed = 15;// airspeed
    public float groundFriction = 15;


    public int restarPositionX = 0;// para resetear la posicion fase pruebas

    //variables for dynamic jump
    public float lowJumpMultiplier = 4f;//lower than normal gravityScale
    public float normalGravityScale = 5f; //gravity scale in the rigidbody inspector


    private Rigidbody2D rb2d;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        movement();
        //jump();//lo mismo deberia ir en el update()
        //Jump2();
        dynamicJump();
        
    }

    void movement()
    {
        //Horizontal: Aplica una fuerza al pulsar las flechas(izda/dereha) o "A" "D"
        //Vertical: Aplica una fuerza  al pulsar las flechas(Arriba/abajo) o "W" "S"
        //float horizontal = Input.GetAxis("EJE EN EL QUE QUIERES USAR VERTICAL/HORIZONTAL");
        //rb2d.AddForce(Vector2.DIRECCION VECTOR * FUERZA * EJE QUE USAMOS);
        //Si le das a la derecha se mueve a la derecha. SI cambias "right" por "left" se moveria a l izquierda

        float horizontalAxisInput = Input.GetAxis("Horizontal");

        float acceleration = grounded ? groundSpeed : airSpeed;
        //float deceleration = grounded ? groundFriction : 0; para jugar con la friccion al dejar de moverse

        //rb2d.AddForce(Vector2.right * speed * horizontal); //ForceMovement
        rb2d.velocity = new Vector2(horizontalAxisInput * acceleration, rb2d.velocity.y);

        //MODIFICAR ORIENTACION AL MOVERSE
        //Si la velocidad es superior a 0 se cambia la orientacion(en realidad es la escala) en el ejeX a la derecha "1"
        //modifica transform.scale en el hierachy de -1 a 1
        if (horizontalAxisInput > 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        //Si la velocidad es inferior a 0 se cambia la orientacion en el ejeX a la izquierda "-1"
        if (horizontalAxisInput < -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

    }

    void jump()
    {
        //Input.GetButtonDown("Jump")
        if (Input.GetButton("Jump"))
        {
            if (grounded == true)
            {

                //cambiar el getComponent por la variable rb2d declarada arriba aumenta el rendimiento (?)
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            }
        }
    }

    void Jump2()
    {
        if (grounded)
        {
            //velocity.y = 0;

            if (Input.GetButtonDown("Jump"))
            {
                //la formula utilizada es: a = (velocidad final ^2 - velocidad inicial ^2) / 2 * distancia recorrida pero el dato que queremos averiguar es la velocidad inicial
                //por eso, la formula se altera a la escrita en el codigo

                //la aceleracion es la fuerza de la gravedad y la distancia es la altura a la que queremos llegar
                rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Sqrt(2 * jumpForce * Mathf.Abs(Physics2D.gravity.y)));
            }
        }

        //_velocity.y += Physics2D.gravity.y * Time.deltaTime;
    }

    
    void dynamicJump()
    {
        //Input.GetButton("Jump")
        if (Input.GetButton("Jump"))
        {
            if (grounded == true)
            {

                //cambiar el getComponent por la variable rb2d declarada arriba aumenta el rendimiento (?)
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            }
        }

        
        if (rb2d.velocity.y > 0.00f && Input.GetButton("Jump"))//while jumping button is pressed gravity is lower(higher jump)
        {
            Debug.Log("saltando sin pulsar el boton - " + rb2d.velocity.y);
            rb2d.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb2d.gravityScale = normalGravityScale;
        }
       
    }

}
