using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{

    public float speed = 3f;
    public float distanceToPlayer = 5f;
    public bool startMoving = false;
    private Transform target;

    //variable vector 2 to lock the movement in the Y axis when enmy is following
    private Vector2 finalPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > distanceToPlayer && startMoving == true)
        {

            finalPosition = new Vector2(target.position.x, transform.position.y);

            //                                       enemy position,     player position with position.y locked at enemy position.y
            transform.position = Vector2.MoveTowards(transform.position, new Vector2( target.position.x, transform.position.y) , speed * Time.deltaTime);

          
        }
        
    }



   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            startMoving = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            startMoving = false;
        }
    }
    

}
