using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 1;               // The amount of health taken away per attack.

    //Animator anim;                              // Reference to the animator component.
    GameObject enemy;                          // Reference to the player GameObject.
    EnemyHealth enemyHealth;                  // Reference to the player's health.
    //EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool enemyInRange;                         // Whether player is within the trigger collider and can be attacked.


    void Awake()
    { 
        //anim = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Dont know which is better other.gameObject.layer or other.gameObject.tag
        //if(other.gameObject.layer == 12) //12 is the enemy layer 
        // If the entering collider is a enemy...
        if (other.gameObject.tag == "Enemy")
        {
            //Take the component of the other object a execute the TakeDamage() function
            //other.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            if (other.gameObject.GetComponentInParent<EnemyHealth>())
            {
                other.gameObject.GetComponentInParent<EnemyHealth>().TakeDamage(attackDamage);
            }
            else
            {
                other.gameObject.GetComponentInParent<BossHealth>().TakeDamage(attackDamage);
            }
            //esto se puede arreglar haciendo un gamobject publico y poniendo el script ahi. SUpongo que es mejor opcion
            //quiza cambiando el tag de enemy por boss. QUiza esto sea lo mejor

        }
    }

    void Update()
    {
        
    }


   
}
