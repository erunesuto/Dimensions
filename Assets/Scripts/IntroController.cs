using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//The fade in, fade on of the text is made with an animation of the text and its trasparency.
public class IntroController : MonoBehaviour
{
    public string sceneName = "Scene1";
    private int count = 0; //manage the text is showing
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKey)
        if (Input.anyKeyDown)
        {
            Debug.Log("A key or mouse click has been detected");
            //animator.SetTrigger("NextText");
            animator.SetBool("Next", true);
            count++;
        }

        if(animator.GetBool("Next") && count > 1)
        {
           SceneManager.LoadScene(sceneName);
        }
    }
}
