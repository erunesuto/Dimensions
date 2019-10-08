using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] float _speed = 9;
    [SerializeField] float _walkAcceleration = 75;
    [SerializeField] float _airAcceleration = 30;
    [SerializeField] float _groundDeceleration = 70;
    [SerializeField] float _jumpHeight = 4;

    private BoxCollider2D _boxCollider;
    private Vector2 _velocity;
    private bool _grounded;

    

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //Collision();
        Jump();
    }

    void Movement()
    {
        transform.Translate(_velocity * Time.deltaTime);

        //Con moveInput recogemos el control del jugador y con MoveTowards cambia la velocidad utilizando un objetivo
        float moveInput = Input.GetAxisRaw("Horizontal");

        //Cambia el valor de aceleracion y deceleracion dependiendo de si el personaje está en el suelo o no
        float acceleration = _grounded ? _walkAcceleration : _airAcceleration;
        float deceleration = _grounded ? _groundDeceleration : 0;

        //Asigna a la velocidad la aceleracion o deceleracion segun se este moviendo el personaje o no
        if (moveInput != 0)
        {
            _velocity.x = Mathf.MoveTowards(_velocity.x, _speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            _velocity.x = Mathf.MoveTowards(_velocity.x, 0, deceleration * Time.deltaTime);
        }
    }

    /*void Collision()
    {
        //Con esta funcion detectamos los objetos con los que colisiona el objeto, ya que al no usar rigidbody se tiene que detectar manualmente
        //Esta funcion nos devuelve un array de colliders con los que se ha chocado el objeto
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, _boxCollider.size, 0);

        _grounded = false;

        foreach (Collider2D hit in hits)
        {
            //Esta linea sirve para que ignore el propio collider del objeto, ya que tambien lo detecta
            if (hit == _boxCollider) continue;

            //Esta linea devuelve un objeto con informacion como, por ejemplo, si dos colliders estan tocandose
            ColliderDistance2D colliderDistance = hit.Distance(_boxCollider);

            //Cuando el objeto choque con un collider, haremos que el objeto salga de ese collider a la distancia minima requerida para que no lo llegue a tocar
            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                //Esta linea calcula si la normal de una superficie tiene menos de 90 grados con respecto al mundo y si la velocidad en la y es menor que 0, para comprobar si el personaje está en el suelo
                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && _velocity.y < 0)
                {
                    _grounded = true;
                }
            }
        }
    }*/

    void Jump()
    {
        if (_grounded)
        {
            _velocity.y = 0;

            if (Input.GetButtonDown("Jump"))
            {
                //la formula utilizada es: a = (velocidad final ^2 - velocidad inicial ^2) / 2 * distancia recorrida pero el dato que queremos averiguar es la velocidad inicial
                //por eso, la formula se altera a la escrita en el codigo

                //la aceleracion es la fuerza de la gravedad y la distancia es la altura a la que queremos llegar
                _velocity.y = Mathf.Sqrt(2 * _jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        _velocity.y += Physics2D.gravity.y * Time.deltaTime;
    }
}
