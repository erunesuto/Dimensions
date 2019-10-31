using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 50f;
    private Rigidbody2D rb2d;
    public float lifeTime = 3f;
  
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //transform.right makes bullets goes to the side players is facing
        //rb2d.velocity = transform.right * speed;
        //Destroy(gameObject, lifeTime);//destroy gameObject
        
    }

    private void Update()
    {
        rb2d.velocity = transform.right * speed;
    }
}
