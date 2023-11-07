using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
   public GameObject objetoADisparar; // Objeto que se va a disparar
    public float velocidadDisparo; // Velocidad a la que se dispara el objeto

    public float time;

    public float shotTime;

    public bool isActive;

    

    void Update()
    {
          time += Time.deltaTime;

        if(isActive&&shotTime < time)
          {

              Disparar();
              time = 0;
          }

      
    }

    void Disparar()
    {
        GameObject disparo = Instantiate(objetoADisparar, transform.position, Quaternion.identity); // Crea una copia del objeto a disparar en la posición actual
        Rigidbody2D rb = disparo.GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D del objeto disparado

        if (rb != null)
        {
            rb.AddForce(transform.right * velocidadDisparo, ForceMode2D.Impulse); // Aplica una fuerza hacia la derecha al objeto
        }
    }
}
