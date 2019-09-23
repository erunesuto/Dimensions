using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerDetector : MonoBehaviour
{

    GameObject player;
    Vector2 pointPlayer;
    Vector2 sizePlayer;

    public LayerMask frontLayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //find the player
    }
    
    // Update is called once per frame
    void Update()
    {
        pointPlayer = new Vector2(player.transform.position.x, player.transform.position.y);
        sizePlayer = new Vector2(1.5f, 5.5f);//the size of the capsule collider of the player
       
        //bool isOverlappingFrontLayer = Physics2D.OverlapCapsule(playerPosition, playerHeight, CapsuleDirection2D.Vertical, playerEulerAngleZ, frontLayerMask) != null;
        bool isOverlappingFrontLayer = Physics2D.OverlapCapsule(pointPlayer, sizePlayer, CapsuleDirection2D.Vertical, 0, frontLayer) != null;
        Debug.Log(isOverlappingFrontLayer);
       /* if (isOverlappingFrontLayer)
        {
            // capsule is overlapping front layer
            //Debug.Log("overlaping with frontLayer");
        }*/
    }

}
