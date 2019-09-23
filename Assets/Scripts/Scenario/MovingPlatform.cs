using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public float speed;

    private Vector3 start, end;

    
    //public Vector3[] localNodes = new Vector3[1];

    // Use this for initialization
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }

        if (transform.position == target.position)
        {
            //si la posicion actual es start se mueve a end. Si no es al reves
            target.position = (target.position == start) ? end : start;
        }
    }

    //Controla que el personaje se mueva con la plataforma al entrar en contacto con la misma
    //Hace al jugador hijo de la plataforma para conseguir que se muevan juntos
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    //Hace que el jugador no sea hijo de la plataforma
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
