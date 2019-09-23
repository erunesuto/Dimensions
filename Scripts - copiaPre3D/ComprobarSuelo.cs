using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//accede al script controladorPJ y modifica la variable enSUelo
public class ComprobarSuelo : MonoBehaviour {

    public ControladorPJ controladorPJ;

	// Use this for initialization
	void Start () {
        controladorPJ = GetComponentInParent<ControladorPJ>();

	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        controladorPJ.enSuelo = true;
        //Debug.Log("entrando");
    }

    

    private void OnCollisionStay2D(Collision2D collision)
     {
         controladorPJ.enSuelo = true;

     }

    /*private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.tag == "escenario"){
            controladorPJ.enSuelo = true;
        }
    }*/

    private void OnCollisionExit2D(Collision2D collision)
    {
        controladorPJ.enSuelo = false;
        //Debug.Log("saliendo");
    }

 

}
