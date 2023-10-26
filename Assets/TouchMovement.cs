using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Camera mainCamera;

    public Collider2D myCollider;
    public bool isTouched = false;

  


     public Transform upperLimit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
         if (Input.touchCount > 0) // Verifica si hay toques en la pantalla
        {
            Touch touch = Input.GetTouch(0); // Obtiene el primer toque en la pantalla

            if (touch.phase == TouchPhase.Began) // Verifica si el toque comienza en la pantalla
            {
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, mainCamera.nearClipPlane));

                if (myCollider.OverlapPoint(touchPosition)) // Verifica si el toque está dentro de los límites del objeto
                {
                    isTouched = true; // Establece la variable isTouched en verdadero si el toque está dentro del objeto
                }
            }

            if (isTouched && (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)) // Verifica si el objeto está siendo tocado y si el toque se está moviendo o estático
            {
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, mainCamera.nearClipPlane));

                // Limita la posición en el eje Y
                if (touchPosition.y < upperLimit.position.y)
                {
                    transform.position = new Vector3(touchPosition.x, touchPosition.y, 0f); // Actualiza la posición del objeto con la posición del toque convertida
                }
                else
                {
                    transform.position = new Vector3(touchPosition.x, upperLimit.position.y, 0f); // Ajusta la posición en el eje Y al límite superior
                }
            }

            if (touch.phase == TouchPhase.Ended) // Verifica si el toque ha terminado
            {
                isTouched = false; // Restablece la variable isTouched a falso cuando el toque ha terminado
            }
        }
    }
}
