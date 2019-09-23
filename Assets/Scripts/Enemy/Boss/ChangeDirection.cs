using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    public SlimeBossMovement slimeBossMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //1 is the position in the array(targetArray) in SlieBossMovement Script
        //1 means the target(gameObject) on the rigth side of the boss area. When the direction is to the right the sprites looks to the right.
        if (slimeBossMovement.actualTarget == 1)
        {
            transform.localScale = new Vector3(-5, 5, 0);
        }
        else
        {
            transform.localScale = new Vector3(5, 5, 0);
        }
    }
}
