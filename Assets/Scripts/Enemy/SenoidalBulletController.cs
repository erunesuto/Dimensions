using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenoidalBulletController : MonoBehaviour
{
    //NO TENGO NI PUTA IDEA DE PORQUE FUNCIONA, MEJOR NO USARLO.
    public float speed = 1;
    public float amplitude = 1;
    public float frecuence = 5;
    public int attackDamage = 1;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //amplitude and frecuence must be in proportion to "maintain" de senoidal effect. Faster = increase both( amplitude and frecuence)
        var pos = transform.position;
        pos.y += Mathf.Sin(Time.time * frecuence -80) /** 0.5f*/;//dunno wtf -80 works.The result is fine. <3 maths
        //pos.y = Mathf.Sin(20);

        transform.position = Vector2.MoveTowards(transform.position, pos, amplitude * Time.deltaTime);

        rb2d.velocity = transform.right * speed;


        /*
     var pos = transform.position;
     pos.y += Mathf.Sin(Time.time*180)*0.5;
     var bulletClone : Rigidbody2D = Instantiate(bulletFlamethrower, pos, transform.rotation);
     bulletClone.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
     bulletClone.AddForce(bulletClone.transform.right * bulletSpeed);

        You may want to change the 180 (how frequently it cycles) and the 0.5 (how much the height varies) 
         */

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Dont know which is better other.gameObject.layer or other.gameObject.tag
        //if(other.gameObject.layer == 12) //12 is the enemy layer 
        // If the entering collider is a enemy...
        if (other.gameObject.tag == "Player")
        {
            //Take the component of the other object a execute the TakeDamage() function
            if (other.gameObject.GetComponent<PlayerHealth>())
            {
                other.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(attackDamage);
                this.gameObject.SetActive(false);
            }

        }
    }

}
