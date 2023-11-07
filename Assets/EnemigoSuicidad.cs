using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSuicidad : MonoBehaviour
{
  public float velocidad;
    private Transform jugador;

    void Start()
    {
        // Encuentra la referencia al jugador
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (jugador != null)
        {
            // Calcula la dirección hacia el jugador
            Vector2 direccion = (jugador.position - transform.position).normalized;

            // Mueve al enemigo hacia el jugador
            transform.position += new Vector3(direccion.x, direccion.y, 0) * velocidad * Time.deltaTime;

            // Haz que el enemigo mire al jugador
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
        }
    }
}
