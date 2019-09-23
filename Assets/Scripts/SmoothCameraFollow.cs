using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;//Cuanto menos sea mas tarda en moverse la camra
    public Vector3 offset;//en el offset es la posicion. La Z es la profundidad, -10 por defecto

    private void FixedUpdate()
    {
        //NO se muy bien porque se Vector3, debe ser por la profundida de la camara y renderice bien todo lo de detras
         Vector3 desiredPosition = target.position + offset;
         Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
         transform.position = smoothedPosition;

    

        //transform.LookAt(target);
    }
}
