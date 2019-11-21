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




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.layer == 9)
        //if(collision.tag == "Scenario")
        {
            playerController.grounded = true;
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        //if (collision.tag == "Scenario")
        {
            playerController.grounded = false;
        }
    }

}
