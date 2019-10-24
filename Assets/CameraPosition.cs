using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPosition : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Camera cam;
    public CinemachineVirtualCamera vcam;

    private CinemachineFramingTransposer transposer;

    
    
    // Start is called before the first frame update
    void Start()
    {
        transposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteRenderer.flipX == false)
        {
            transposer.m_ScreenX = Mathf.Lerp(0.55f, 0.45f, 0.5f * Time.deltaTime);
            //transposer.m_ScreenX = 0.45f;
            //transposer.m_BiasX = 0.3f;
            //vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        }else if (spriteRenderer.flipX == true)
        {
            transposer.m_ScreenX = Mathf.Lerp(0.45f, 0.55f, 1 * Time.deltaTime);
            //transposer.m_ScreenX = 0.55f;
            //transposer.m_BiasX = -0.3f;
        }
    }
}
