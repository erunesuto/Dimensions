using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenoidalBulletController : MonoBehaviour
{

    public float moveSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.y += Mathf.Sin(Time.time * 5) * 1;
        //pos.y = Mathf.Sin(20);

        transform.position = Vector2.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime);

    }
}
