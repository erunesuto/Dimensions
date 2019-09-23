using UnityEngine;

public class Audio : MonoBehaviour {
    
    public static Audio  audio; //el new no se para que es, sin el "new" daba warning de encapsulamiento o algo asi
   // public static AudioSource audioSourceMenu;
    //public static AudioSource audioSourceJuego;
    public AudioClip clipAudio;
    public float volumen=0.1f;
    //bool activarInicio = true;

    void Awake()
    {
        if (audio == null)
        {
            //this hace referencia a la estancia del componente que esta ejecutando este codigo
            audio = this;
            DontDestroyOnLoad(gameObject);
        }
        //si es distinto de la estancia actual se destruye
        else if (audio != this)
        {
            Destroy(gameObject);
        }
        //AudioMenu.audioMenu.GetComponent<AudioSource>().Play();

       
            AudioSource.PlayClipAtPoint(clipAudio, Camera.main.transform.position, volumen);
          
    }

    // Use this for initialization
    void Start () {
        //AudioSource.PlayClipAtPoint(clipAudio, Camera.main.transform.position, volumen);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
