using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    GameObject player;
    //GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //find the player
        //camera = GameObject.FindGameObjectWithTag("MainCamera"); //find the camera
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(0, 0, 0);
            Vector3 destinyPosition = new Vector3 (player.transform.position.x, player.transform.position.y, -11);
            Vector3 position = Vector3.Lerp(new Vector3(0, 0, transform.position.z), destinyPosition, 0.01f);
            transform.position = position;

            Debug.Log("leftArrow");
        }
    }
}
