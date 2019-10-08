using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 50f;
    private Rigidbody2D rb2d;
    //public GameObject parent;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.forward * speed;
        //rb2d.velocity = transform.right * speed * parent.transform.localScale.x;
    }
}
