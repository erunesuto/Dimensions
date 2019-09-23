using UnityEngine;

public class ActivarGameOver : MonoBehaviour
{

    public GameObject camaraGameOver;
    public AudioClip gameOverClip;
    public Camera camara;//basura infecta
    // Use this for initialization
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
    }

    void PersonajeHaMuerto(Notification notificacion)
    {
        
        camara.GetComponent<AudioSource>().Stop();
        camara.GetComponent<AudioSource>().clip = gameOverClip;
        camara.GetComponent<AudioSource>().loop = false;
        //GetComponent<AudioSource>().Play();
        camaraGameOver.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
