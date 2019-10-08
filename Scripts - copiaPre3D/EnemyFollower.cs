﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public int velocidad= 0;
    public Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        // la variable rb2d hace referencia al rigidbody del objeto al que asignamos el script(inspector)
        //rb2d = GetComponent<Rigidbody2D>();
        rb2d = GetComponentInParent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        transform = GetComponentInParent<Transform>();

}


private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //rb2d.AddForce(Vector2.right * velocidad);
            rb2d.velocity = new Vector2(velocidad,0);
            //transform.position = new Vector3 (transform.position.x,transform.position.y+2,transform.position.z);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
}