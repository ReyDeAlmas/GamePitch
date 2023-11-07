using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMinion : MonoBehaviour
{
    public float speed; // Velocidad de movimiento del enemigo
    public Transform leftLimit; // Objeto que representa el límite izquierdo
    public Transform rightLimit; // Objeto que representa el límite derecho
    public float maxHeight; // Altura máxima de movimiento hacia abajo
    private bool moveRight = true;
    private float originalY;



    private void Start()
    {
        originalY = transform.position.y;
    }

    private void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= rightLimit.position.x)
            {
                moveRight = false;
                transform.position = new Vector2(transform.position.x, transform.position.y - maxHeight);
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= leftLimit.position.x)
            {
                moveRight = true;
                transform.position = new Vector2(transform.position.x, transform.position.y - maxHeight);
            }
        }
    }

   

}
