using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controla que salte mas alto cuanto mas pulses el boton
public class PlayerJumping : MonoBehaviour 
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb2d.velocity.y);
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if(rb2d.velocity.y > 0 && !Input.GetButton("Jump")){//Aqui hay que tocar
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
    }
}
