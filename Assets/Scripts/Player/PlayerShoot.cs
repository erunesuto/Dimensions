using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject shot;
    public Transform shotSpawn;
    public Vector3 finalShotSpawn;
    private Transform player;

    public float fireRate = 0f;

    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        if (Input.GetButton("Shoot") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

    }

}
