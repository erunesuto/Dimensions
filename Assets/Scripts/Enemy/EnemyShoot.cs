using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    private SpriteRenderer enemySprite;
    public Transform shotSpawn;

    public float timeBetweenShots = 3f;
    private float nextFire;
    public bool canFire = false;//flag

    private ObjectPooler objectPooler;



    // Start is called before the first frame update
    void Start()
    {
        enemySprite = GetComponentInParent<SpriteRenderer>();
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {        
        repositionShootSpawn();
        shoot();
    }


    void shoot()
    {
  
        //objectPooler.spawnFromPool("Bullet", shotSpawn.position, Quaternion.identity);//no se que es el quaternion identity :/
        //objectPooler.spawnFromPool("FollowerBullet", shotSpawn.position, shotSpawn.rotation);

        if (canFire && Time.time > nextFire)
        {
            nextFire = Time.time + timeBetweenShots;
            objectPooler.spawnFromPool("FollowerBullet", shotSpawn.position, shotSpawn.rotation);
        }
    }

    void repositionShootSpawn()
    {
        if (enemySprite.flipX == true)
        {
            shotSpawn.rotation = new Quaternion(shotSpawn.rotation.x, 180, shotSpawn.rotation.x, shotSpawn.rotation.w);
        }
        else if (enemySprite.flipX == false)
        {
            shotSpawn.rotation = new Quaternion(shotSpawn.rotation.x, 0, shotSpawn.rotation.x, shotSpawn.rotation.w);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canFire = true;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canFire = false;
            
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Trigger stay");
        }
        
        if (collision.gameObject.tag == "Player" && Time.time > nextFire)
        {
            nextFire = Time.time + timeBetweenShots;
            //shoot();
            Debug.Log("Shoot stay");
        }
    }*/

}
