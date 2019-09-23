using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    //Floats
    public float smoothTimeY;
    public float smoothTimeX;

    //GameObjects
    public GameObject player;

    //Booleans
    public bool bounds;

    //Positions
    private Vector2 velocity;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //Camera Follow for X & Y
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
            Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }

    public void SetMinCamPosition()
    {
        minCameraPos = gameObject.transform.position;
    }

    public void SetMaxCamPosition()
    {
        maxCameraPos = gameObject.transform.position;
    }
}
