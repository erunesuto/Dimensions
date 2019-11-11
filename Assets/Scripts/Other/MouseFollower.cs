using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{

    private Vector3 mousePosition;
    public float speed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mouse = Input.mousePosition;
            mouse.z = 20f; // Set this to be the distance you want the object to be placed in front of the camera.
            //this.transform.position = Camera.main.ScreenToWorldPoint(mouse);
            transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(mouse), speed * Time.deltaTime);

            if (transform.position == Camera.main.ScreenToWorldPoint(mouse))
            {
                this.gameObject.SetActive(false);
            }
        }

        
    }
}
