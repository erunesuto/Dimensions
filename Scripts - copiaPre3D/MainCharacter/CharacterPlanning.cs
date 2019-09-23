using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlanning : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public bool planningAvailable = false;
    private float startPlanningTime;//Variable para el tiempo
    public float planningTimeLimit;//Hasta que tiempo(segundo) puede planear antes de empezar a caer
    public float planningDuration = 1000;//duracipn de tiempo que se va a mantener en el aire antes de caer
    private ControladorPJ controladorPJ;

    // Start is called before the first frame update
    void Start()
    {
        // la variable rb2d hace referencia al rigidbody del objeto al que asignamos el script(inspector)
        rb2d = GetComponent<Rigidbody2D>();
        controladorPJ = GetComponentInParent<ControladorPJ>();//accede al script controladorPJ del padre
    }

    // Update is called once per frame
    void Update()
    {
        canIPlan();//comprueba si puede planear o no
        startPlanning();

    }

    void startPlanning()
    {
        if (planningAvailable == true)
        {
            //Congela el movimiento en el ejeY, desplazamiento solo horizontal(VOLAR)
            if (Input.GetKeyDown(KeyCode.Q))
            {
                planningAvailable = false;
                startPlanningTime = Time.realtimeSinceStartup * 1000;//tiempo actual, cuadno se pulsa el boton para planear ms
                planningTimeLimit = startPlanningTime + planningDuration;// un segundo mas tarde, cuanto ya no se puede planear

                //This is called a bitwise operation.
                rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
        }
        

        if(Time.realtimeSinceStartup *1000 >= planningTimeLimit)
        {
            rb2d.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
      
        
    }

    void canIPlan()
    {
        if (controladorPJ.enSuelo == true)
        {
            planningAvailable = true;
        }
    }

}
