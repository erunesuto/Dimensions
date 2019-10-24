using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldEnemyFollower : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public int velocidad= 0;
    public Transform transform; //comentado posible error
    public int direction;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // la variable rb2d hace referencia al rigidbody del objeto al que asignamos el script(inspector)
        //rb2d = GetComponent<Rigidbody2D>();
        rb2d = GetComponentInParent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //transform = GetComponentInParent<Transform>();

    }

    //activate the walkin animation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Follow", true);
        }
    }

    //desactivate the walkin animation
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Follow", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            //anim.SetTrigger("ActivateFollow");
            //rb2d.AddForce(Vector2.right * velocidad);
            rb2d.velocity = new Vector2(velocidad,rb2d.velocity.y);
            transform.localScale = new Vector3 (direction, 1,1);
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
}
