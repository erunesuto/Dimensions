﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 50f;
    private Rigidbody2D rb2d;
    public float lifeTime = 3f;
    public int attackDamage = 1;

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



        /* Vector3 mouse = Input.mousePosition;
         mouse.z = 20f; // Set this to be the distance you want the object to be placed in front of the camera.
                        //this.transform.position = Camera.main.ScreenToWorldPoint(mouse);
         transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(mouse), speed * Time.deltaTime);
         */
        /* if(transform.position == Camera.main.ScreenToWorldPoint(mouse))
         {
             this.gameObject.SetActive(false);
         }*/
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

        if (other.gameObject.layer == 9)//if layer is scenario
        {
            this.gameObject.SetActive(false);
        }
    }

}