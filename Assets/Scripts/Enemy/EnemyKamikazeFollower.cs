using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikazeFollower : MonoBehaviour
{
    #region Variables
    public float speed = 10f;//movement speed
    public float distanceToPlayer = 10f;//distance enemy left between himself and the player
    public float distanceToRetreat = 9f;
    public bool canMove = false;

    private Transform player;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    //variables to adjust the speed according the distance
    private float speedAdjustedToDistance;//the more far the enemy is the faster he moves
    public float distanceSpeedOffset = 15f;//a cocient to reduce/adjust the speed according the distance

    //variable to detects collisions with Scenario
    public float rayLenght = 2f;
    private Vector2 lowerPosition;//lower position for raycasts. COntrols interactions wiht Scenerio layer
    public float lowerPositionositionY = -2;//Y position origin to lower raycast
    private Vector2 upperPosition;//upper position for raycasts. COntrols interactions wiht Scenerio layer
    public float upperPositionositionY = 2;//Y position origin to upper raycast
    public bool grounded;

    private bool canJump = true; //flag
    public float jumpSpeed = 20;//adjusted to "perfect" jump

    LayerMask scenarioLayer;

    public float timeFollowingAfterLoseVision;//time we want enemy still following after lose vision of player
    private float timeVisionIsLost;

    private bool canResetTimeVisionLost = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        rb2d = GetComponentInParent<Rigidbody2D>();

        scenarioLayer = LayerMask.GetMask("Scenario");

        timeVisionIsLost = -2;//initialize the value to bugfix, i guess

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void movement()
    {
        //absolute value. //the more far the enemy is the faster he moves
        speedAdjustedToDistance = Mathf.Abs((transform.root.position.x - player.position.x) / distanceSpeedOffset);

        //Enemy move towards the player
        if (Mathf.Abs(transform.position.x - player.position.x) > distanceToPlayer && canMove == true)
        {
            //   root = very most top parent              enemy position,     player position with position.y locked at enemy position.y
            transform.root.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime * speedAdjustedToDistance);
        }//Enemy retreats from player
        else if (Mathf.Abs(transform.position.x - player.position.x) < distanceToRetreat && Mathf.Abs(transform.position.y - player.position.y) < distanceToRetreat && canMove == true)
        {
            transform.root.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime * -1);
        }

    }

    void flipSPrite()
    {
        //normal right, flip left
        if (transform.position.x < player.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    void checkingScenarioCollisions()
    {
        #region raycast adjustment
        //to modify raycast in the inspector, remove after test phase
        lowerPosition.x = transform.position.x;
        lowerPosition.y = transform.position.y + lowerPositionositionY;

        upperPosition.x = transform.position.x;
        upperPosition.y = transform.position.y + upperPositionositionY;


        //                    origin, direction
        //Ray2D ray = new Ray2D(lowerPosition, Vector2.right);//lower right


        //Debug.DrawRay(lowerPosition, Vector2.right * rayLenght);//lower right
        //Debug.DrawRay(lowerPosition, Vector2.left * rayLenght);//lower left
        #endregion

        //solo se activa si el fixedTime es menos que la suma de timepos(3 segundo)
        //algo asi, la segundalinea a lo mejor se puede quitar?
        if (Time.fixedTime < (timeVisionIsLost + timeFollowingAfterLoseVision))
        // && (!Physics2D.Linecast(transform.position, player.position, scenarioLayer) || Physics2D.Linecast(transform.position, player.position, scenarioLayer)))
        {
            canMove = true;

        }
        else if (Physics2D.Linecast(transform.position, player.position, scenarioLayer) && Time.fixedTime > (timeVisionIsLost + timeFollowingAfterLoseVision))
        {
            canMove = false;
        }


        if (grounded)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }


        //if the wall is too high enemy cannot jump.2 raycast from the top(head) of the enemy to left and right to detects high walls. Upperright and upper left
        if (Physics2D.Raycast(upperPosition, Vector2.right, rayLenght, scenarioLayer) || Physics2D.Raycast(upperPosition, Vector2.left, rayLenght, scenarioLayer))
        {
            canJump = false;

            if (Mathf.Abs(transform.position.x - player.position.x) < distanceToRetreat)
            {
                canMove = false;
            }
        }


        //2raycast from the lower(feet) of the enemy to detect if theres is a obstacle and jump it
        //the !spriteRenderer.flipX manage to dont jump when moving to the right the left raycast collision with scenario behind enemy and allow him to jump again.
        if (Physics2D.Raycast(lowerPosition, Vector2.right, rayLenght, scenarioLayer) && canJump && grounded && canMove)//lower right
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        else if (Physics2D.Raycast(lowerPosition, Vector2.left, rayLenght, scenarioLayer) && canJump && grounded && canMove)//lower left
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (/*collision.tag == "Player"*/ collision.CompareTag("Player") && !Physics2D.Linecast(transform.position, player.position, scenarioLayer))
        {
            canMove = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !Physics2D.Linecast(transform.position, player.position, scenarioLayer))
        {
            canResetTimeVisionLost = true;
        }

        if (collision.CompareTag("Player") && canResetTimeVisionLost && Physics2D.Linecast(transform.position, player.position, scenarioLayer))
        {
            timeVisionIsLost = Time.fixedTime;
            canResetTimeVisionLost = false;
        }

        if (collision.CompareTag("Player") && canResetTimeVisionLost && !Physics2D.Linecast(transform.position, player.position, scenarioLayer))
        {
            canMove = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canMove = false;
        }
    }

}
