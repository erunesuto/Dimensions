using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//tiene un script complementario en los bloques changePlaneBlock
public class ChangePlanePlayer : MonoBehaviour
{
    // referenses to controlled game objects
    //public GameObject avatar1, avatar2;
    private Animator animator;
    public Animator animatorTilemap;
    public ParticleSystem ps;
    public Tilemap frontTilemap;
    public Tilemap backTilemap;
    //quiza se podria cambiar los tilemaps por layer y unificarlo un poco(?)
    public LayerMask frontLayer;
    public LayerMask backLayer;


    // variable contains which avatar is on and active
    public int whichAvatarIsOn = 1;

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 11, true); //ignore the backScenario tileMap
        // enable first avatar and disable another one
        //avatar1.gameObject.SetActive(true); testing1
       // avatar2.gameObject.SetActive(false); testing1
        animator = GetComponent<Animator>();  

    }

    private void Update()
    {

        

        var pointPlayer = new Vector2(transform.position.x, transform.position.y);
        var sizePlayer = new Vector2(0.9f, 5.4f);//the size of the capsule collider of the player. This is not perfect.

        //bool isOverlappingFrontLayer = Physics2D.OverlapCapsule(playerPosition, playerHeight, CapsuleDirection2D.Vertical, playerEulerAngleZ, frontLayerMask) != null;
        bool isOverlappingFrontLayer = Physics2D.OverlapCapsule(pointPlayer, sizePlayer, CapsuleDirection2D.Vertical, 0, frontLayer) != null;
        bool isOverlappingBackLayer = Physics2D.OverlapCapsule(pointPlayer, sizePlayer, CapsuleDirection2D.Vertical, 0, backLayer) != null;

        //Change plane

        if (Input.GetButtonDown("ChangePlane"))
        {
            
            if (!isOverlappingFrontLayer && !isOverlappingBackLayer)
            {
                SwitchAvatar();
            }
            //SwitchAvatar();

        }
        //if the position change is in the switch() it does not work properly
        if (whichAvatarIsOn == 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }

    }

    // public method to switch avatars by pressing UI button
    public void SwitchAvatar()
    {
        var main = ps.main;// manage particleSYstem. Change color. Other method is deprecated

        

        // processing whichAvatarIsOn variable and manage all things necesaries to the correct change of plane
        switch (whichAvatarIsOn)
        {

            // if the first avatar is on 1
            case 1:
 
                main.startColor = new Color(1, 1, 1, 1);    //Set particles color to black                                                                                          
                Instantiate(ps, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); //instantiate particle system

                animator.SetBool("HaraBlackForm", true); //To change animations to BlackHara(backScenario)
                animatorTilemap.SetBool("BackTransparent", false);
                //Change collision with layers
                Physics2D.IgnoreLayerCollision(8, 10, true);//Active collision with frontScenario
                Physics2D.IgnoreLayerCollision(8, 11, false);//Desactive collision with backScenario
                // then the second avatar is on now
                whichAvatarIsOn = 2;
                

                // disable the first one and anable the second one
                //avatar1.gameObject.SetActive(false); testing1
                //avatar2.gameObject.SetActive(true); testing1
                break;

            // if the second avatar is on 2
            case 2:
                
                /*LIMPIAR DE MIERDA. HACER 2 ANIMATOR 1 PARA HARA Y OTRO PARA LOS TILES*/

                main.startColor = new Color(0, 0, 0, 1);    //Set particles color to black                                                                                 
                Instantiate(ps, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); //instantiate particle system

                animator.SetBool("HaraBlackForm", false); //To change animations to WhiteHara(frontScenario)
                animatorTilemap.SetBool("BackTransparent", true);
                //Change collision with layers
                Physics2D.IgnoreLayerCollision(8, 10, false);//Desactive collision with frontScenario
                Physics2D.IgnoreLayerCollision(8, 11, true);//Active collision with backScenario

                // then the first avatar is on now
                whichAvatarIsOn = 1;

                // disable the second one and anable the first one
                //avatar1.gameObject.SetActive(true);testing1
                //avatar2.gameObject.SetActive(false);testing1
                break;
        }

    }


    /*private void SetTileColour(Color colour, Vector3Int position, Tilemap tilemap)
    {
        // Flag the tile, inidicating that it can change colour.
        // By default it's set to "Lock Colour".
        tilemap.SetTileFlags(position, TileFlags.None);

        // Set the colour.
        tilemap.SetColor(position, colour);
    }*/

}
