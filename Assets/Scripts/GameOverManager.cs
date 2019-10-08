﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;       // Reference to the player's health.
    public float restartDelay = 5f;         // Time to wait before restarting the level


    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level


    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        // If the player has run out of health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");

            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {
                //CONTROLAR QUE SE REINICIE LA PARTIDA AL PULSAR UN BOTON, UN ANIMACION QUIZA(?)

                // .. then reload the currently loaded level.
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //cargar la escena      con el nombre de la escena actual
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}