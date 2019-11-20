using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCBulletController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb2d;
    private bool initialMoving = true;//flag
    public int attackDamage = 5;

    private float startInactiveTime;//moment when it start to count to destroy the RCBullet while not moving
    public float inactiveTime = 0.15f; //period of time the player can not press any button and the RCBullet is not destroy, seconds
    private bool canDestroyBullet;//flag
    private bool mouseClick; //flag

    private ObjectPooler objectPooler;
    private GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.gravityScale = 1;
        camera = GameObject.FindGameObjectWithTag("MainCamera"); //find the camera
    }

    // Update is called once per frame
    void Update()
    {
        movement();

    }

    void movement()
    {

        float horizontalAxisInput = Input.GetAxisRaw("Horizontal2");
        float verticalAxisInput = Input.GetAxisRaw("Vertical2");


        if (initialMoving == true)//starting moving speed. Disappear when player moves the RCBullet with joystick
        {
            rb2d.velocity = transform.right * speed / 4;
            
        }
        else
        {
            rb2d.gravityScale = 0;
            rb2d.velocity = new Vector2(horizontalAxisInput * speed, verticalAxisInput * speed);

            if (canDestroyBullet == true && horizontalAxisInput == 0 && verticalAxisInput == 0 && Input.GetMouseButton(1) == false)
            {
                startInactiveTime = Time.fixedTime;
                canDestroyBullet = false;//flag
            }

            if (Input.GetMouseButton(1))
            {
                mouseClick = true;//flag
            }
            if (mouseClick)
            {
                Vector3 mouse = Input.mousePosition;                 

                mouse.z = -camera.transform.position.z;// Set this to be the distance you want the object to be placed in front of the camera.

                transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(mouse), speed * Time.deltaTime);

                if (transform.position == Camera.main.ScreenToWorldPoint(mouse))
                {
                    mouseClick = false;//flag
                    this.gameObject.SetActive(false);
                }
            }


        }

        
        //Destroy the RCBullet
        if( initialMoving == false && horizontalAxisInput == 0 && verticalAxisInput == 0 && !mouseClick && Time.fixedTime >= startInactiveTime + inactiveTime)
        {      
            initialMoving = true;//restart the flag
            canDestroyBullet = true;//restart the flag
            this.gameObject.SetActive(false);
        }

        
        //change flags if the human player moves the RCBullet
        if (horizontalAxisInput > 0)
        {
            horizontalAxisInput = 1;
            initialMoving = false;
            canDestroyBullet = true;//restart the flag
        }
        else if (horizontalAxisInput < 0)
        {
            horizontalAxisInput = -1;
            initialMoving = false;
            canDestroyBullet = true;//restart the flag
        }
        else if (verticalAxisInput > 0)
        {
            verticalAxisInput = 1;
            initialMoving = false;
            canDestroyBullet = true;//restart the flag
        }
        else if (verticalAxisInput < 0)
        {
            initialMoving = false;
            verticalAxisInput = -1;
            canDestroyBullet = true;//restart the flag
        }else if(Input.GetMouseButton(1))//the one for the keyboard+mouse controlles
        {
            initialMoving = false;
            //canDestroyBullet = true;//restart the flag
        }

    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
       //destroy the bullet if enemy collision and deal damage
        if (other.gameObject.tag == "Enemy")
        {
            //Take the component of the other object a execute the TakeDamage() function
            //other.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            if (other.gameObject.GetComponentInParent<EnemyHealth>())
            {
                other.gameObject.GetComponentInParent<EnemyHealth>().TakeDamage(attackDamage);
                this.gameObject.SetActive(false);
            }
            else//for boss( manage life boss bar i guess)
            {
                other.gameObject.GetComponentInParent<BossHealth>().TakeDamage(attackDamage);
                this.gameObject.SetActive(false);
            }
            //esto se puede arreglar haciendo un gamobject publico y poniendo el script ahi. SUpongo que es mejor opcion
            //quiza cambiando el tag de enemy por boss. QUiza esto sea lo mejor

        }

        //destroy the bullet if scenario collision
        if (other.gameObject.layer == 9)//if layer is scenario
        {
            initialMoving = true;//restart the flag
            canDestroyBullet = true;//restart the flag
            this.gameObject.SetActive(false);
        }
    }

}
