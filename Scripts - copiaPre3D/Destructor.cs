using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{   
    //public object JugadorEstrella { get; private set; }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //se activa/avisa cuando colisiona algun collider con los collider con la opcion "is trigger" activa
    void OnTriggerEnter2D(Collider2D other)
    {
        //Si el tag es "Player" entra al if
        if (other.tag == "Player")
        {
            //Si un objeto con el tag "Player" colisiona con los collider con "is trigger" activo quiere decir que el pj o se ha salido por arriba
            //o por abajo, es decir, el pj ha muerto

            //Si el pj colisiona con un collider "on trigger" y el tag es "Player" se envia una notificacion de "PersonajeHaMuerto"
            NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
            //personaje vale JugadorEstrella
            GameObject personaje = GameObject.Find("CirculoCompleto 1");
            //desactiva a personaje que vale JugadorEstrella, se para el juego, hemos muerto
            personaje.SetActive(false);
            //Debug.Break();
        }
        /*else
        {
            //si no destruye el objeto
            Destroy(other.gameObject);
        }*/
    }
}
