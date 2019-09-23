//This example enables and disables the GameObject's Collider when the space bar is pressed.
//Attach this to a GameObject and attach a Collider to the GameObject

using UnityEngine;

public class ColliderOnOff : MonoBehaviour
{
    Collider2D m_Collider;

    void Start()
    {
        //Fetch the GameObject's Collider (make sure it has a Collider component)
        m_Collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //Toggle the Collider on and off when pressing the space bar
            m_Collider.enabled = !m_Collider.enabled;

            //Output to console whether the Collider is on or not
            Debug.Log("Collider.enabled = " + m_Collider.enabled);
        }
    }

}