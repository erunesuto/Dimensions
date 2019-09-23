using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashingBlockDamage : MonoBehaviour
{


    public bool readyToSmash = false;


    public float speed = 10f;

    public Transform target; //Smashing detector
    private Vector3 start, end;
    AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponentInParent<AudioSource>();

        if (target != null)
        {
            //target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    //cre que el fallo viene de aqui
    void FixedUpdate()
    {
        if (target != null && readyToSmash)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);

        }

        if (transform.position == target.position)
        {
            //si la posicion actual es start se mueve a end. Si no es al reves
            target.position = (target.position == start) ? end : start;

            if (target.position == start)
            {
                source.Play();//play the smash sound
            }
        }
        //cuando la posicion del bloque vuelve al inicio se reinicia la bandera
        if (transform.position == start)
        {
            readyToSmash = false;

        }


        //por que al ejecutar el juego el detector del smashblock no es hijo del padre? funciona bien pero por que?
        //esto no funca bien
        /*if (target.position == start)
        {
            speed *= .5f;
        }*/

        //hacer que cuando vuleva a su posicion original vaya mas lento, la mitad
    }



    /*Hacer una funcion que ponga a "smashing" a false solo cuando el bloque llegue a su posicion original
     * habra que guardar la posicion original en una variable (solo posicion Y)
     * el movimiento de smash tiene que se hasta la posicion del detector. INterpolacion? funcion lerp()?
     * 
     * */
}
