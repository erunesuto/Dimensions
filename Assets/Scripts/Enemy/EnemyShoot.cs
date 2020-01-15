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

    public string bullet;
    private Transform player;

    LayerMask scenarioLayer;

    // Start is called before the first frame update
    void Start()
    {
        enemySprite = GetComponentInParent<SpriteRenderer>();
        objectPooler = ObjectPooler.Instance;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        scenarioLayer = LayerMask.GetMask("Scenario");
    }

    // Update is called once per frame
    void Update()
    {

        shootSpawnRotation();
        //repositionShootSpawn();
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


    void shootSpawnRotation()
    {


        //Vector3 difference = Camera.main.ScreenToWorldPoint(mousePos) - shotSpawn.transform.position;
        Vector3 difference = transform.position - player.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        shotSpawn.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180);//180 is an offset

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !Physics2D.Linecast(transform.position, player.position, scenarioLayer))
        {
            canFire = true;
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (!Physics2D.Linecast(transform.position, player.position, scenarioLayer))
            {
                canFire = true;
            }

            if (Physics2D.Linecast(transform.position, player.position, scenarioLayer))
            {
                canFire = false;
            }
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
