using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public bool grounded;
    public float jumpForce = 400f;
    public float jumpSpeed = 20f;
    public float maxFallingSpeed = -20f;//quiza int mejor que float

    // variables Version2
    public float groundSpeed = 20;//groundSpeed
    public float airSpeed = 15;// airspeed
    //public float groundFriction = 15;

    //variables for dynamic jump
    public float jumpGravityScale = 3.5f;//lower than normal gravityScale
    public float fallingGravityScale = 6f; //Gravity while player is falling
    public float normalGravityScale = 5f; //gravity scale in the rigidbody inspector
    

    //variables dynamic jump v2
    private bool jumping = false;//if is jumping (ascending)
    private float jumpTimeCounter;
    public float jumpTime = 0.35f;//time in the air

    public bool doubleJump = true;
    public float doubleJumpSpeed = 10f;

    //variable dynamic jump v3
    public bool stoppedJumping;
    //private float jumpTimeCounter;
    //public float jumpTime = 0.35f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //ojo
        //jumpTimeCounter = jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        dynamicJump();
        //dynamicJump2();
       //dynamicJump3();
        //debugLogs();
    }

    void FixedUpdate()
    {
        movement();
        //jump();//lo mismo deberia ir en el update()
        //Jump2();
        //dynamicJump();

    }

    void movement()
    {
        //Horizontal: Aplica una fuerza al pulsar las flechas(izda/dereha) o "A" "D"
        //Vertical: Aplica una fuerza  al pulsar las flechas(Arriba/abajo) o "W" "S"
        //float horizontal = Input.GetAxis("EJE EN EL QUE QUIERES USAR VERTICAL/HORIZONTAL");
        //rb2d.AddForce(Vector2.DIRECCION VECTOR * FUERZA * EJE QUE USAMOS);
        //Si le das a la derecha se mueve a la derecha. SI cambias "right" por "left" se moveria a l izquierda

        float horizontalAxisInput = Input.GetAxisRaw("Horizontal");
        
        if (horizontalAxisInput > 0)
        {
            horizontalAxisInput = 1;

        }else if(horizontalAxisInput < 0)
        {
            horizontalAxisInput = -1;
        }

        float speed = grounded ? groundSpeed : airSpeed;
        //float deceleration = grounded ? groundFriction : 0; para jugar con la friccion al dejar de moverse

        //rb2d.AddForce(Vector2.right * speed * horizontal); //ForceMovement
        rb2d.velocity = new Vector2(horizontalAxisInput * speed, rb2d.velocity.y);

        //max speed falling limit
        if( rb2d.velocity.y <= maxFallingSpeed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxFallingSpeed);
        }

        //MODIFICAR ORIENTACION AL MOVERSE
        //Si la velocidad es superior a 0 se cambia la orientacion(en realidad es la escala) en el ejeX a la derecha "1"
        //modifica transform.scale en el hierachy de -1 a 1
        if (horizontalAxisInput > 0.01f)
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            spriteRenderer.flipX = false;

        }
        //Si la velocidad es inferior a 0 se cambia la orientacion en el ejeX a la izquierda "-1"
        if (horizontalAxisInput < -0.01f)
        {
            //transform.localScale = new Vector3(-1f, 1f, 1f);
            spriteRenderer.flipX = true;
        }

        //animator running
        if (rb2d.velocity.x != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
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
        if (grounded == true)
        {
            doubleJump = true;
        }

        if (Input.GetButtonDown("Jump") && grounded == true )
        //if (Input.GetButton("Jump"))
        {

            //cambiar el getComponent por la variable rb2d declarada arriba aumenta el rendimiento (?)
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);

            //rb2d.AddForce(Vector2.up * jumpForce);   
        }

        //doubleJump///////////////////////////////////
        if (Input.GetButtonDown("Jump") && grounded == false && doubleJump == true )
        {          
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, doubleJumpSpeed);
            doubleJump = false;
        }
        //////////////////////////////////////////////

        if (rb2d.velocity.y > 0.00f && Input.GetButton("Jump"))//while jumping button is pressed gravity is lower(higher jump)
        {
            rb2d.gravityScale = jumpGravityScale;

        }else if(rb2d.velocity.y < 0.00f && grounded == false)
        {
            rb2d.gravityScale = fallingGravityScale;
        }
        else
        {
            rb2d.gravityScale = normalGravityScale;
        }

        
    }


    void dynamicJump2()
    {
        if (Input.GetButtonDown("Jump") && grounded == true)
        //if (Input.GetButton("Jump"))
        {
           
            jumping = true;
            jumpTimeCounter = jumpTime;
            rb2d.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump") && jumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                jumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            jumping = false;
        }
    }


    void dynamicJump3()
    {
        if (grounded)
        {
            //the jumpcounter is whatever we set jumptime to in the editor.
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetButton("Jump") && grounded == true)
        //if (Input.GetButton("Jump"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            stoppedJumping = false;
        }

        //if you keep holding down the mouse button...
        if (Input.GetButton("Jump") && !stoppedJumping)
        {
            //and your counter hasn't reached zero...
            if (jumpTimeCounter > 0)
            {
                //keep jumping!
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            //stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
    }

    void debugLogs()
    {
        //Debug.Log("Y position " + rb2d.position.y);
        //Debug.Log("Y velocity " + rb2d.velocity.y);
        Debug.Log("Y velocity " + rb2d.gravityScale);
    }
}


