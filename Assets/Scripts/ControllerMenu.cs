using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour {

    public string nombreEscenaParaCargar = "GameScene";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            Application.Quit();

        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            SceneManager.LoadScene(nombreEscenaParaCargar);

        }

        //MOdificar para poner un tercer boton para volver atras y howToPlay
        /*if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            SceneManager.LoadScene(nombreEscenaParaCargar);

        }*/

    }




}
