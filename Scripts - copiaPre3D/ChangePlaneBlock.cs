using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tiene un script complementario en el jugador(Ara) changePlaneCharacter
public class ChangePlaneBlock : MonoBehaviour
{
    Collider2D collider;

    void Start()
    {
        //Fetch the GameObject's Collider (make sure it has a Collider component)
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Toggle the Collider on and off when pressing the space bar
            collider.enabled = !collider.enabled;

            //Output to console whether the Collider is on or not
            Debug.Log("Collider.enabled = " + collider.enabled);
        }
    }
}
