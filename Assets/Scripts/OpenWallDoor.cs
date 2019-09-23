using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWallDoor : MonoBehaviour
{

    public GameObject wallDoor;
    public GameObject boss;

    AudioSource mainTheme;
    AudioSource bossTheme;
    AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        mainTheme = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>(); //find the audioSource of the camera
        bossTheme = GameObject.FindGameObjectWithTag("BossActivator").GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!boss)
        {
            bossTheme.Stop();
            source.Play();
            mainTheme.Play();
            
            Destroy(wallDoor);
        }
        
    }


}
