using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bullet;
    public GameObject rcbullet;
    public Transform shotSpawn;
    public Vector3 finalShotSpawn;
    private SpriteRenderer playerSprite;

    public float timeBetweenShots = 0f;
    private float nextFire;

    private ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponentInParent<SpriteRenderer>();
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
        if (Input.GetButton("Fire") && Time.time > nextFire)
        {
            nextFire = Time.time + timeBetweenShots;
            //Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

            //objectPooler.spawnFromPool("Bullet", shotSpawn.position, Quaternion.identity);//no se que es el quaternion identity :/
            objectPooler.spawnFromPool("Bullet", shotSpawn.position, shotSpawn.rotation);
        }

        if (Input.GetButton("FireRC") && Time.time > nextFire)
        {
            nextFire = Time.time + timeBetweenShots;
            //Instantiate(rcbullet, shotSpawn.position, shotSpawn.rotation);
            objectPooler.spawnFromPool("RCBullet", shotSpawn.position, shotSpawn.rotation);
        }

    }

    //controls the position of the shootSpawn to shoot in the correct direction. If the player flips the shootSpawn flips too
    void repositionShootSpawn()
    {
        if (playerSprite.flipX == true)
        {
            shotSpawn.rotation = new Quaternion(shotSpawn.rotation.x, 180, shotSpawn.rotation.x, shotSpawn.rotation.w);
        }
        else if (playerSprite.flipX == false)
        {
            shotSpawn.rotation = new Quaternion(shotSpawn.rotation.x, 0, shotSpawn.rotation.x, shotSpawn.rotation.w);
        }
    }
}
