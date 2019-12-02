using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerBulletController : MonoBehaviour
{
    //Bullet of red enemy.
    public float moveSpeed = 15f;
    private Transform player;
    private float startTime;
    public float lifeTime = 1;
    private float lifeTimeStarts;//when the bullet spawn
    private bool destroyBullet = true;

    public int attackDamage = 1;
    PlayerHealth playerHealth;
    private EnemyShoot enemyShoot;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = player.GetComponent<PlayerHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(player.position), moveSpeed * Time.deltaTime);//smoother
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        destroy();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Dont know which is better other.gameObject.layer or other.gameObject.tag
        //if(other.gameObject.layer == 12) //12 is the enemy layer 
        // If the entering collider is a enemy...
        if (other.gameObject.tag == "Player")
        {
            //Take the component of the other object a execute the TakeDamage() function
            if (other.gameObject.GetComponent<PlayerHealth>())
            {
                other.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(attackDamage);
                this.gameObject.SetActive(false);
            }

        }

        //desactivate the bullet
        if (other.gameObject.layer == 9)//if layer is scenario
        {
            //this.gameObject.SetActive(false);
            this.transform.root.gameObject.SetActive(false);//the very most top parent of the tree
        }

    }


    private void destroy()
    {
        if (destroyBullet)
        {
            destroyBullet = false;
            lifeTimeStarts = Time.fixedTime;
        }

        if(Time.fixedTime >= lifeTimeStarts + lifeTime)
        {
            destroyBullet = true;
            gameObject.SetActive(false);
        }
    }
}
