using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSpinner : MonoBehaviour
{
    public float velocidad;
    public float distanciaMinima;
    public float velocidadGiro;
    private Transform jugador;
    private bool girando = false;


    public EnemyShot enemyShot;

  

    void Start()
    {
        // Encuentra la referencia al jugador
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

      
    }

    void Update()
    {
        if (jugador != null)
        {
            // Calcula la dirección y la distancia hacia el jugador
            Vector2 direccion = jugador.position - transform.position;
            float distancia = direccion.magnitude;

            if (distancia > distanciaMinima && !girando)
            {
                // Mueve al enemigo hacia el jugador
                transform.position += (Vector3)direccion.normalized * velocidad * Time.deltaTime;
            }
            else
            {
                girando = true;
                
                enemyShot.isActive = true;

                transform.Rotate(Vector3.forward * velocidadGiro * Time.deltaTime);
            }
        }
    }
}
