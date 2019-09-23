using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashingBlockDetector : MonoBehaviour
{

    GameObject player;
    public SmashingBlockDamage smashingBlockDamage;

    private float timeDetection; //the time when detects the collison with the player
    private float timeActivateSmash; // the time when the smash starts
    public float timeDelaySmash = 1f; // the delay between the detection and the smash starts
    private bool startSmash = false;// turns true when player is under de smashBlock


    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); //find the player
    }

    // Update is called once per frame
    void Update()
    {
        //if (timeDetection >= timeActivateSmash && startSmash) //no entiendo porque esto no funciona

        //if the player is under the smash block and after a delay the smash block smash
        if (Time.realtimeSinceStartup * 1000 >= timeActivateSmash && startSmash)
        {

            smashingBlockDamage.readyToSmash = true;
            startSmash = false;

            anim.SetBool("Smash", false);//restarts the flag of the shaking animation of the smash block
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {

            anim.SetBool("Smash", true);//starts the shaking animation of the smash block

            timeDetection = Time.realtimeSinceStartup * 1000;//tiempo actual, en ms
            timeActivateSmash = timeDetection + (timeDelaySmash * 1000);// tiempo cuando comienza el smash, despues de un delay
            startSmash = true;

        }
    }
}
