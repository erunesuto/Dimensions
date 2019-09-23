using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBloques : MonoBehaviour {

    public float incremento;
    public float distancia;
   // Vector3 posicion;
	// Use this for initialization
	void Start () {

        for (float i = 0; i < distancia; i += incremento)
        {
            //posicion = new Vector3(1,0,0);
            //rb2d.velocity = new Vector2(velocidadLimite, rb2d.velocity.y);
            transform.position = new Vector3(1 + incremento, 0, 0);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
        

	}
}
