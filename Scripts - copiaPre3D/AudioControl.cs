using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControl : MonoBehaviour
{
    public static AudioControl audioControl;
    static bool AudioBegin = true;

    void Awake()
    {
        if (audioControl == null)
        {
            //this hace referencia a la estancia del componente que esta ejecutando este codigo
            audioControl = this;
            DontDestroyOnLoad(gameObject);
        }
        //si es distinto de la estancia actual se destruye
        else if (audioControl != this)
        {
            Destroy(gameObject);
        }

        /* if (!AudioBegin)
         {
             GetComponent<AudioSource>().Play();
             DontDestroyOnLoad(gameObject);
             AudioBegin = true;
         }*/
    }
    private void Start()
    {
        //asigna el nombre de la escena actual a una variable
        /*Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Debug.Log(sceneName);*/
    }
    void Update()
    {
        //simplificar en funcion(?) consume mucha bateria (?)
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        //Debug.Log(sceneName);

        if (sceneName == "Scene1" || sceneName == "Scene2")

        {
            GetComponent<AudioSource>().Stop();
            AudioBegin = false;
        }
        //
        if ((AudioBegin == false) && ((sceneName == "TitleScene") || (sceneName == "ScenarioSelection")))
        {
           // Debug.Log("dentro del if que reactiva el audio");
            GetComponent<AudioSource>().Play();
            AudioBegin = true;
        }
    }
}