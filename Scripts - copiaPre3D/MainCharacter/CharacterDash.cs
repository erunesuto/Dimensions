using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : MonoBehaviour
{
    float ButtonCooler = 0.5f; // Half a second before reset
    int ButtonCount = 0;
    public int dashSpeed =100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {

            if (ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/)
            {
                //Has double tapped
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * dashSpeed, GetComponent<Rigidbody2D>().velocity.y);
                Debug.Log("double tap");

            }
            else
            {
                ButtonCooler = 0.5f;
                ButtonCount += 1;
            }
        }

        if (ButtonCooler > 0)
        {

            ButtonCooler -= 1 * Time.deltaTime;

        }
        else
        {
            ButtonCount = 0;
        }
    }
}
