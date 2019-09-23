using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonCargarEscena : MonoBehaviour
{

    public string nombreEscenaParaCargar = "GameScene";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnMouseDown()
    {
        //LO MISMO HAY QUE PULIRLO. HA SIDO UN COPY/PASTE

        //detiene el audio de la camara y luego reproduce el del boton jugar
        //Camera.main.GetComponent<AudioSource>().Stop();
         GetComponent<AudioSource>().Play();
        //Invoke("CargarNivelJuego",1);
        Invoke("CargarNivelJuego", GetComponent<AudioSource>().clip.length);
    }

    void CargarNivelJuego()
    {
        SceneManager.LoadScene(nombreEscenaParaCargar);
    }
}
