using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMeteorito : MonoBehaviour
{
    public float rotationSpeed;
    public float collisionDamaged;

    public GameObject playerObject;
  

    // Update is called once per frame
    void Update()
    {
      
        // Hace que el objeto gire sobre su propio eje z local en 2D
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Mueve el objeto hacia abajo en el eje y local del objeto en 2D
        playerObject = GameObject.FindGameObjectWithTag("Player");
       
     }


      private void OnTriggerEnter2D(Collider2D other)
    {
        
        

        if(other.gameObject.CompareTag("Player"))
        {
           

            playerObject.GetComponent<Player>().damaged(collisionDamaged);
        
        }
       
    }
}
