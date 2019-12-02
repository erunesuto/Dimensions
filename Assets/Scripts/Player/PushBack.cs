using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{
    public int force = 1000;
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
            // normalize force vector to get direction only and trim magnitude

            //if player is on the floor the push is bigger(dunno why need more force)
            /*var offset = 1;
            if (GetComponent<PlayerController>().grounded)
            {
                offset = 3;
            }
            else
            {
                offset = 1;
            }*/

            direction.Normalize();
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }
}
