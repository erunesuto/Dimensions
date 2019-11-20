using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSettings : MonoBehaviour
{
    public static bool xboxController;
    void Start()
    {
        joystickConnected();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void joystickConnected()
    {
        if (Input.GetJoystickNames()[0].Length == 33)
        {
            xboxController = true;
        }
        else
        {
            xboxController = false;
        }
        //autoinvoke after 3 second to optimize the performance
        Invoke("joystickConnected", 3);
    }

}
