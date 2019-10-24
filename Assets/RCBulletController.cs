using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCBulletController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private bool initialMoving = true;
    // Start is called before the first frame update
    void Start()
    {
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
        }else
        {
            rb2d.velocity = new Vector2(horizontalAxisInput * speed, verticalAxisInput * speed);
        }

        if( initialMoving == false && horizontalAxisInput == 0 && verticalAxisInput == 0)
        {
            Debug.Log("podeberia desapareser");

        }

        if (horizontalAxisInput > 0)
        {
            horizontalAxisInput = 1;
            initialMoving = false;
        }
        else if (horizontalAxisInput < 0)
        {
            horizontalAxisInput = -1;
            initialMoving = false;
        }
        else if (verticalAxisInput > 0)
        {
            verticalAxisInput = 1;
            initialMoving = false;
        }
        else if (verticalAxisInput < 0)
        {
            initialMoving = false;
            verticalAxisInput = -1;
        }


        
    }
}
