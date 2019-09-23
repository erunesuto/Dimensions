using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Manage the buttons

public class LoadScene : MonoBehaviour
{
    public string sceneName = "Intro";
    AudioSource source;
    public float delayTime = 1;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        source.Play();   
    }



    public void loadScene()
    {
        
        Time.timeScale = 1f;//basicamente para descongelar el tiempo en el menu de pausa, quiza no sea necesario en un futuro. Testing
        SceneManager.LoadScene(sceneName);
    }

    //load a scene after a delay time(after the click sound has ended)
    public void delayLoadScene()
    {
        source.Play();
        Invoke("loadScene", source.clip.length);
    }

    public void exit()
    {
        source.Play();
        Application.Quit();
    }

}
