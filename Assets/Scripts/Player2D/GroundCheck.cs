using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//accede al script controladorPJ y modifica la variable enSUelo
public class GroundCheck : MonoBehaviour {

    //private PlayerController playerController; //hace referencia al script PlayerController
    private PlayerController playerController;
    // Use this for initialization
    void Start () {
        playerController = GetComponentInParent<PlayerController>();
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController.grounded = true;
        //Debug.Log("entrando");
    }

    private void OnCollisionStay2D(Collision2D collision)
     {
        playerController.grounded = true;

     }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerController.grounded = false;

    }
    

/*
    private void OnTriggerEnter(Collider collision)
    {
        playerController.grounded = true;
        //Debug.Log("entrando");
    }

    private void OnTriggerStay(Collider collision)
    {
        playerController.grounded = true;

    }

    private void OnTriggerExit(Collider collision)
    {
        playerController.grounded = false;

    }*/
}
