using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioCollisions : MonoBehaviour
{
    
    public float rayLenght = 2;
    private Vector2 lowerPosition;//lower position for raycasts. COntrols interactions wiht Scenerio layer
    public float lowerPositionositionY = -2;//Y position origin to lower raycast
    private Vector2 upperPosition;//upper position for raycasts. COntrols interactions wiht Scenerio layer
    public float upperPositionositionY = 2;//Y position origin to upper raycast

    private bool canJump = true; //flag

    private Rigidbody2D rb2d;
    
    private SpriteRenderer spriteRenderer;

    LayerMask scenarioLayer;
    LayerMask playerLayer;
    public float jumpSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
        scenarioLayer = LayerMask.GetMask("Scenario");
        playerLayer = LayerMask.GetMask("Player");
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        //to adjust raycast in the inspector, remove after test phase
        lowerPosition.x = transform.position.x;
        lowerPosition.y = transform.position.y + lowerPositionositionY;

        upperPosition.x = transform.position.x;
        upperPosition.y = transform.position.y + upperPositionositionY;



        //                    origin, direction
        Ray2D ray = new Ray2D(lowerPosition, Vector2.right);//lower right


        //Debug.DrawRay(lowerPosition, Vector2.right * rayLenght);//lower right
        //Debug.DrawRay(lowerPosition, Vector2.left * rayLenght);//lower left


         Debug.DrawRay(lowerPosition, Vector2.right * rayLenght *4);
        if (Physics2D.Raycast(lowerPosition, Vector2.right, rayLenght * 4, playerLayer))//raycast to the player
        {
            Debug.Log("tocandoplayer"); //tocar por aqui
        }

        //if the wall is too high enemy cannot jump.2 raycast from the top(head) of the enemy to left and right to detects high walls. Upperright and upper left
        if (Physics2D.Raycast(upperPosition, Vector2.right, rayLenght, scenarioLayer) || Physics2D.Raycast(upperPosition, Vector2.left, rayLenght, scenarioLayer))
        {
            canJump = false;
        }

        //2raycast from the lower(feet) of the enemy to detect if theres is a obstacle and jump it
        if (Physics2D.Raycast(lowerPosition, Vector2.right, rayLenght, scenarioLayer) && canJump && !spriteRenderer.flipX)//lower right
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        else if(Physics2D.Raycast(lowerPosition, Vector2.left, rayLenght, scenarioLayer) && canJump && spriteRenderer.flipX)//lower left
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        canJump = true;

    }

    void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        Gizmos.DrawRay(lowerPosition, Vector2.right * rayLenght);//lower right
        Gizmos.DrawRay(lowerPosition, Vector2.left * rayLenght);//lower left

        Gizmos.color = Color.red;
        Gizmos.DrawRay(upperPosition, Vector2.right * rayLenght);//lower right
        Gizmos.DrawRay(upperPosition, Vector2.left * rayLenght);//lower left


    }

}
