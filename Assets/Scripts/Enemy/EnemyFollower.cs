using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{

    public float speed = 10f;//movement speed
    public float distanceToPlayer = 10f;//distance enemy left between himself and the player
    public bool canMove = false;

    private Transform player;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    //variables to adjust the speed according the distance
    private float speedAdjustedToDistance;//the more far the enemy is the faster he moves
    public float distanceSpeedOffset = 15f;//a cocient to reduce/adjust the speed according the distance

    //variable to detects collisions with Scenario
    public float rayLenght = 2;
    private Vector2 lowerPosition;//lower position for raycasts. COntrols interactions wiht Scenerio layer
    public float lowerPositionositionY = -2;//Y position origin to lower raycast
    private Vector2 upperPosition;//upper position for raycasts. COntrols interactions wiht Scenerio layer
    public float upperPositionositionY = 2;//Y position origin to upper raycast
    public bool grounded;

    private bool canJump = true; //flag
    public float jumpSpeed = 10;

    LayerMask scenarioLayer;
    //LayerMask playerLayer;
    // LayerMask allLayers = Physics2D.AllLayers;//test

    public float timeFollowingAfterLoseVision;//time we want enemy still following after lose vision of player
    private float timeVisionIsLost;
    private bool playerVision = true;


    
    private bool canResetTimeVisionLost = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();       
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        rb2d = GetComponentInParent<Rigidbody2D>();

        scenarioLayer = LayerMask.GetMask("Scenario");
        //playerLayer = LayerMask.GetMask("Player");


        timeVisionIsLost = -2;
    }

    // Update is called once per frame
    void Update()
    {
        checkingScenarioCollisions();
        movement();
        flipSPrite();

    }


    void movement()
    {
        //absolute value. //the more far the enemy is the faster he moves
        speedAdjustedToDistance = Mathf.Abs((transform.root.position.x - player.position.x) / distanceSpeedOffset);

        if (Vector2.Distance(transform.position, player.position) > distanceToPlayer && canMove == true)
        {

            //   root = very most top parent              enemy position,     player position with position.y locked at enemy position.y
            transform.root.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime * speedAdjustedToDistance);

        }
    }

    void flipSPrite()
    {

        if (transform.position.x < player.position.x)
        {
            spriteRenderer.flipX = false;

        }
        else
        //if (transform.position.x > target.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }

   
    void checkingScenarioCollisions()
    {
        //to modify raycast in the inspector, remove after test phase
        lowerPosition.x = transform.position.x;
        lowerPosition.y = transform.position.y + lowerPositionositionY;

        upperPosition.x = transform.position.x;
        upperPosition.y = transform.position.y + upperPositionositionY;



        //                    origin, direction
        //Ray2D ray = new Ray2D(lowerPosition, Vector2.right);//lower right


        //Debug.DrawRay(lowerPosition, Vector2.right * rayLenght);//lower right
        //Debug.DrawRay(lowerPosition, Vector2.left * rayLenght);//lower left


        //solo se activa si el fixedTime es menos que la suma de timepos(3 segundo)
        //Optimizar esto, es repetitivo
        if ((!Physics2D.Linecast(transform.position, player.position, scenarioLayer) && Time.fixedTime < (timeVisionIsLost + timeFollowingAfterLoseVision))
            || (Physics2D.Linecast(transform.position, player.position, scenarioLayer) && Time.fixedTime < (timeVisionIsLost + timeFollowingAfterLoseVision)))
        {
            canMove = true;
            
        }else if (Physics2D.Linecast(transform.position, player.position, scenarioLayer) && Time.fixedTime > (timeVisionIsLost + timeFollowingAfterLoseVision) /*&& !visionLost*/)
        {
            canMove = false;
           

            //canResetTimeVisionLost = true;// ha perdidio la vision, la proxima vez que lo vea y lo pierda de vista reinicia el timeVIsionLost
        }

        
        //Debug.DrawLine(transform.position, player.position);
        //Debug.Log("fixeTime "+Time.fixedTime + " timeVisionLost " + timeVisionIsLost +" timeFollowing " + timeFollowingAfterLoseVision + " suma "+ (timeVisionIsLost + timeFollowingAfterLoseVision) + " canResetTimeVisionLost: " + canResetTimeVisionLost);


        //if the wall is too high enemy cannot jump.2 raycast from the top(head) of the enemy to left and right to detects high walls. Upperright and upper left
        if (Physics2D.Raycast(upperPosition, Vector2.right, rayLenght, scenarioLayer) || Physics2D.Raycast(upperPosition, Vector2.left, rayLenght, scenarioLayer))
        {
            canJump = false;
        }

        //2raycast from the lower(feet) of the enemy to detect if theres is a obstacle and jump it
        //the !spriteRenderer.flipX manage to dont jump when moving to the right the left raycast collision with scenario behind enemy and allow him to jump again.
        if (Physics2D.Raycast(lowerPosition, Vector2.right, rayLenght, scenarioLayer) && canJump && !spriteRenderer.flipX && grounded && canMove)//lower right
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        else if (Physics2D.Raycast(lowerPosition, Vector2.left, rayLenght, scenarioLayer) && canJump && spriteRenderer.flipX && grounded && canMove)//lower left
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        canJump = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !Physics2D.Linecast(transform.position, player.position, scenarioLayer))
        {
            canMove = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        /////////////
        ///hay que pulir y limpiar algunas cosas
        
        if (collision.tag == "Player" && !Physics2D.Linecast(transform.position, player.position, scenarioLayer))
        {
            canResetTimeVisionLost = true;
        }

        if (collision.tag == "Player" && canResetTimeVisionLost && Physics2D.Linecast(transform.position, player.position, scenarioLayer))
        {
            timeVisionIsLost = Time.fixedTime;
            canResetTimeVisionLost = false;
        }

        if(collision.tag == "Player" && canResetTimeVisionLost && !Physics2D.Linecast(transform.position, player.position, scenarioLayer))
        {
            canMove = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canMove = false;
        }
    }


    void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
       /* Gizmos.DrawRay(lowerPosition, Vector2.right * rayLenght);//lower right
        Gizmos.DrawRay(lowerPosition, Vector2.left * rayLenght);//lower left

        Gizmos.color = Color.red;
        Gizmos.DrawRay(upperPosition, Vector2.right * rayLenght);//lower right
        Gizmos.DrawRay(upperPosition, Vector2.left * rayLenght);//lower left*/


    }

}
