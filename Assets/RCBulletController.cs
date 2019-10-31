using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCBulletController : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb2d;
    private bool initialMoving = true;//flag

    private float startInactiveTime;//moment when it start to count to destroy the RCBullet while not moving
    public float inactiveTime = 0.25f; //period of time the player can not press any button and the RCBullet is not destroy, seconds
    private bool canDestroyBullet;//flag

    private ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        rb2d = GetComponent<Rigidbody2D>();
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
            rb2d.velocity = new Vector2(horizontalAxisInput * speed, verticalAxisInput * speed);

            if(canDestroyBullet == true && horizontalAxisInput == 0 && verticalAxisInput == 0)
            {
                startInactiveTime = Time.fixedTime;
                canDestroyBullet = false;//flag
            }
            
        }

        
        //Destroy the RCBullet
        if( initialMoving == false && horizontalAxisInput == 0 && verticalAxisInput == 0 && Time.fixedTime >= startInactiveTime + inactiveTime)
        {      
            initialMoving = true;//restart the flag
            canDestroyBullet = true;//restart the flag
            this.gameObject.SetActive(false);
        }

        

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
        }


        
    }
}
