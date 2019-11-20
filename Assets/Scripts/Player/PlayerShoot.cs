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


    //shotspawn dierection
    private Vector2 direction;
    private float angle;

    //shotspawn direction2
    public float offset = 180;

    public GameObject crosshair;
    public float crosshairDistanceMultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponentInParent<SpriteRenderer>();
        objectPooler = ObjectPooler.Instance;


        //player = GameObject.FindGameObjectWithTag("Player"); //find the player
    }

    // Update is called once per frame
    void Update()
    {

        if(OtherSettings.xboxController)
        {
            shootSpawnRotationJoystick();
        }
        else
        {
            shootSpawnRotationMouse();
            
            
        }

        shoot();
    }

    void shoot()
    {

        var horizontalAxis = Input.GetAxisRaw("Horizontal2");
        var verticalAxis = Input.GetAxisRaw("Vertical2");

        if (Input.GetButton("Fire") && Time.time > nextFire)
        {
            nextFire = Time.time + timeBetweenShots;
            //Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

            //objectPooler.spawnFromPool("Bullet", shotSpawn.position, Quaternion.identity);//no se que es el quaternion identity :/
            objectPooler.spawnFromPool("Bullet", shotSpawn.position, shotSpawn.rotation);//shotSpawn.rotation is the rotation of the bullet(same at the shotSpawn)
            //objectPooler.spawnFromPool("Bullet", crosshair.transform.position, shotSpawn.rotation);
        }


        if (Input.GetButton("FireRC") && Time.time > nextFire)
        {
            nextFire = Time.time + timeBetweenShots;
            repositionFlipShootSpawn();
            //Instantiate(rcbullet, shotSpawn.position, shotSpawn.rotation);
            objectPooler.spawnFromPool("RCBullet", shotSpawn.position, shotSpawn.rotation);
          
        }

    }

    //controls the position of the shootSpawn to shoot in the correct direction. If the player flips the shootSpawn flips too
    void repositionFlipShootSpawn()
    {
       
        if (playerSprite.flipX == false )
        {
         
            shotSpawn.rotation = new Quaternion(shotSpawn.rotation.x, shotSpawn.rotation.y, 0, shotSpawn.rotation.w);
        }else if (playerSprite.flipX == true  )
        {
          
            shotSpawn.rotation = new Quaternion(shotSpawn.rotation.x, 180, 0, shotSpawn.rotation.w);
        }
    }


    //360 degrees rotation with mouse
    void shootSpawnRotationMouse()
    {
        //Mouse has just 2D, you have to set the z position because the ScreenToWorldPoint uses vector3
        var mousePos = Input.mousePosition;
        mousePos.z = -10;

        //Vector3 difference = Camera.main.ScreenToWorldPoint(mousePos) - shotSpawn.transform.position;
        Vector3 difference = Camera.main.ScreenToWorldPoint(mousePos) - Camera.main.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        shotSpawn.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
  
    }

    
    //joystick
    void shootSpawnRotationJoystick()
    {
        var horizontalAxis = Input.GetAxisRaw("Horizontal2");
        var verticalAxis = Input.GetAxisRaw("Vertical2");
        var crosshairXPos = 2;
        var crosshairYPos = 2;

        var movementDirection = new Vector2(horizontalAxis, verticalAxis);
        crosshair.transform.localPosition = movementDirection * crosshairDistanceMultiplier;

        if (crosshair.transform.localPosition.x > 2)
        {
            crosshair.transform.localPosition = new Vector2(crosshairXPos, crosshair.transform.localPosition.y);
        }else if (crosshair.transform.localPosition.x < -2)
        {
            crosshair.transform.localPosition = new Vector2(-crosshairXPos, crosshair.transform.localPosition.y);
        }


        if (crosshair.transform.localPosition.y > 2)
        {
            crosshair.transform.localPosition = new Vector2(crosshair.transform.localPosition.x, crosshairYPos);
        }else if (crosshair.transform.localPosition.y < -2)
        {
            crosshair.transform.localPosition = new Vector2(crosshair.transform.localPosition.x, -crosshairYPos);
        }
        

        Vector3 difference = crosshair.transform.position - shotSpawn.transform.position;// a lo mejor cambiar la camara por el player
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        shotSpawn.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

    }

   
}
