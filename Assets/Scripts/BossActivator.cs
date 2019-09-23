using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{

    //public GameObject gameObjectToActivate;
   // public GameObject gameObjectToActivate2;

    public GameObject[] gameObjectsToActivate = new GameObject[2];//2 elements, the boss and the boss door(?)
    //gameObjectsToActivate[0] = boss

    AudioSource mainTheme;
    AudioSource bossTheme;

    // Start is called before the first frame update
    void Start()
    {
        mainTheme = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>(); //find the audioSource of the camera
        bossTheme = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //open the door if the boss is dead. Not using currently
        if (!gameObjectsToActivate[0])
        {
            gameObjectsToActivate[1].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        mainTheme.Stop();//stop the main music
        bossTheme.Play();//starts the boss music

        foreach (GameObject gameObjectToActivate in gameObjectsToActivate)
        {
            gameObjectToActivate.SetActive(true);
        }
    }
}
