using UnityEngine;
using System.Collections;

public class ShootOnAxisInput : MonoBehaviour
{
    //El mio
	public GameObject bullet;

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";

	public float shootDelay = 0.1f;

	private bool canShoot = true;

	
	void ResetShot ()
	{
		canShoot = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
        //Vector2 shootDirection = Vector2.right * Input.GetAxis(horizontalAxis) + Vector2.up * Input.GetAxis(verticalAxis);

        Vector2 shootDirection = new Vector2 (Input.GetAxis(horizontalAxis) , Input.GetAxis(verticalAxis));
        if (shootDirection.sqrMagnitude > 0.0f)
		{
            //transform.rotation = Quaternion.LookRotation(shootDirection,Vector2.up);
            transform.rotation = Quaternion.LookRotation(shootDirection, Vector2.up);

            //lo que hace es invocar la bala con la rotacion del joystick y lo que tiene que pasar es que el shotspawnn rote con el joystic
            //la rotacion solo tiene que ser en el eje z

            if (canShoot)
			{
				Instantiate(bullet,transform.position,transform.rotation);//la rotacion de aqui no es la correcta(creo)
				
				canShoot = false;
				Invoke("ResetShot",shootDelay);
			}
		}
	}
}
