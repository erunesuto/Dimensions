using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    private SpriteRenderer enemySprite;
    public Transform shotSpawn;

    public float timeBetweenShots = 0f;
    private float nextFire;

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
        nextFire = Time.time + timeBetweenShots;
    }


    void shoot()
    {
       
        //nextFire = Time.time + timeBetweenShots;
        //Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

        //objectPooler.spawnFromPool("Bullet", shotSpawn.position, Quaternion.identity);//no se que es el quaternion identity :/
        objectPooler.spawnFromPool("FollowerBullet", shotSpawn.position, shotSpawn.rotation);


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
        if(collision.gameObject.tag == "Player")
        {
            shoot();
        }
    }
}
