using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisionador : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("on triger enter");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("on collision enter");
    }

}
