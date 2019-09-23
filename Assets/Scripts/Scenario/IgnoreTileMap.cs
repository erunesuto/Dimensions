using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreTileMap : MonoBehaviour
{
    public bool ignoreFront = false;
    public bool ignoreBack = false;
    //public ChangePlanePlayer changePlanePlayer;
    ChangePlanePlayer changePlanePlayer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //8 player - 10 front - 11 back - 12 enemy
        //testing. En principio funciona bien. EN vez de añadir el script desde el inspecto lo hago asi.
        player = GameObject.FindGameObjectWithTag("Player"); //find the player
        changePlanePlayer = player.GetComponent<ChangePlanePlayer>();


        if (ignoreFront)
        {
            Physics2D.IgnoreLayerCollision(12, 10, true);//10 is front
        }
        if (ignoreBack)
        {
            Physics2D.IgnoreLayerCollision(12, 11, true); //11 is back
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        //Avatar1 is white, Hara is front. Avatar2 is black, Hara is back
        //Manage de collision with the player in the different planes/situation
        
        //NOTE: DO NOT CHANGE THE ORDER OF THE IFS. IT WILL NOT WORKS PROPERLY
        //if enemy is front and player is front detect collision
        if (ignoreBack && changePlanePlayer.whichAvatarIsOn == 1)//Hara is front
        {
            Physics2D.IgnoreLayerCollision(12, 8, false);
        }

        //if enemy is back and player is front ignore collision
        if (ignoreFront && changePlanePlayer.whichAvatarIsOn == 1)//Hara is front
        {
            Physics2D.IgnoreLayerCollision(12, 8, true);
        }
        //if enemy is front and player is front detect collision
        if (ignoreFront && changePlanePlayer.whichAvatarIsOn == 2)//Hara is back
        {
            Physics2D.IgnoreLayerCollision(12, 8, false);
        }

        //if enemy is front and player is back ignore collision
        if (ignoreBack && changePlanePlayer.whichAvatarIsOn == 2)//Hara is back
        {
            Physics2D.IgnoreLayerCollision(12, 8, true);
        }

    }
}
