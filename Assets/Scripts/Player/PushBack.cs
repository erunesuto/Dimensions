using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{
    public int force = 1000;
    private Vector2 debug;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // If the object we hit is the enemy
        if (collision.gameObject.tag == "Enemy")
        {
          
            // calculate force vector
            var direction = transform.position - collision.transform.position;
            debug = direction;
            // normalize force vector to get direction only and trim magnitude
            direction.Normalize();
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force);


        /*if(collision.transform.position.x < transform.position.x)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
            }else if(collision.transform.position.x > transform.position.x)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
            }*/
        }
    }
}
