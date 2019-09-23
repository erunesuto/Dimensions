using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Time.timeScale
Escala a la que pasa el tiempo. Se puede usar para efectos de cámara lenta.
Cuando timeScale es 1.0 el tiempo pasa igual de rápido que en la vida real. 
Cuando timeScale es 0.5 el tiempo pasa el doble de despacio que en la vida real.
Cuando timeScale se establece a cero básicamente se pausa el juego si todas tus funciones son independientes del frame rate.*/
public class SlowMotion : MonoBehaviour
{
    public bool slowMotion = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (slowMotion == true)
        {

            
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }
}
