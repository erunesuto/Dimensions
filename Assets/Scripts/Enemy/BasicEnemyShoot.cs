using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyShoot : MonoBehaviour
{

    private SpriteRenderer enemySprite;
    public Transform shotSpawn;

    public float timeBetweenShots = 3f;
    private float nextFire;
    public bool canFire = false;//flag

    private ObjectPooler objectPooler;

    public string bullet;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        enemySprite = GetComponentInParent<SpriteRenderer>();
        objectPooler = ObjectPooler.Instance;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        timeBetweenShots *= Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

        //shootSpawnRotation();
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
            objectPooler.spawnFromPool(bullet, shotSpawn.position, shotSpawn.rotation);
        }
    }

    //this is the difference with EnemyShoot
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

}