using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    //private PlayerController playerController; //hace referencia al script PlayerController
    private EnemyFollower enemyFollower;
    // Use this for initialization
    void Start()
    {
        enemyFollower = GetComponentInParent<EnemyFollower>();

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        //if(collision.tag == "Scenario")
        {
            enemyFollower.grounded = true;
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        //if (collision.tag == "Scenario")
        {
            enemyFollower.grounded = false;
        }
    }

}


