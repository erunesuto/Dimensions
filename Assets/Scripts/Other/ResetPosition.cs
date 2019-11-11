using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPosition : MonoBehaviour
{
    public int xPosition = -90;
    public int yPosition = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("r"))
        {
            this.gameObject.transform.position = new Vector2(xPosition, yPosition);
        }

        if (Input.GetKeyDown("t"))
        {
            SceneManager.LoadScene("98IntroSceneTest");
        }
    }
}
