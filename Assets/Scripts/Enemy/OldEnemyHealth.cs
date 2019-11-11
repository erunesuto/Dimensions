using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldEnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth = 50;                                   // The current health the player has.                             
    //public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    //public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.


    //Animator anim; comentado posible fallo                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.                                                                              
    bool isDead;                                                // Whether the player is dead.
    //bool damaged;   comentado posible fallo                                             // True when the player gets damaged.
    public GameObject deathParticles;

    void Awake()
    {
        // Setting up the references.
        //anim = GetComponent<Animator>(); comentado posible fallo
        playerAudio = GetComponent<AudioSource>();
        //playerMovement = GetComponent<PlayerMovement>();
        //playerShooting = GetComponentInChildren<PlayerShooting>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
    }


    void Update()
    {
       
    }


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        //damaged = true; comentado posible fallo

        // Reduce the current health by the damage amount.
        currentHealth -= amount;
        //Instantiate(deathParticles, transform.position, transform.rotation);
        

        // Play the hurt sound effect.
        playerAudio.Play();         //IMPLEMENTAR SONIDO DESPUES



        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        //Instantiate the deathParticles gameObjecto for the "death animation"
        Instantiate(deathParticles, transform.position, transform.rotation);
        Destroy(gameObject);

        // Tell the animator that the player is dead.
        //anim.SetTrigger("Die"); //ANIMACION PARA CUANDO MUERA(?)

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
       // playerAudio.Play();

        // Turn off the movement and shooting scripts.
        //playerMovement.enabled = false;
    }
}