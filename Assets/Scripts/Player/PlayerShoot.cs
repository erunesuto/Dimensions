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



    private Vector2 direction;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponentInParent<SpriteRenderer>();
        objectPooler = ObjectPooler.Instance;

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
        float verticalAxisInput = Input.GetAxisRaw("Vertical2");//lo mismo para el raton
        //ajustar para que cuando el raton este por encima del player dispare para arriba
        // mousePosition.y - shotSpawn.position.y > shotSpawn.position.y maybe

        var mousePosition = Input.mousePosition;
        Debug.Log(mousePosition+" //////"+shotSpawn.position.y);
        if (verticalAxisInput > 0 || mousePosition.y > shotSpawn.position.y)
        {
   
            shotSpawn.rotation = new Quaternion(shotSpawn.rotation.x, shotSpawn.rotation.y, 45,45);//no se por que es asi pero da 90º
        }
        else if (playerSprite.flipX == false )
        {
         
            shotSpawn.rotation = new Quaternion(shotSpawn.rotation.x, shotSpawn.rotation.y, 0, shotSpawn.rotation.w);
        }else if (playerSprite.flipX == true  )
        {
          
            shotSpawn.rotation = new Quaternion(shotSpawn.rotation.x, shotSpawn.rotation.y, 180, shotSpawn.rotation.w);
        }
    }

    void shootSpawnRotation()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shotSpawn.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shotSpawn.rotation = Quaternion.Euler(0f, 0f, angle);

    }
}
