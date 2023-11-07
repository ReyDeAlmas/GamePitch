using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update

    public float health;

    public float collisionDamaged;

    public float points;
    public GameObject playerObject;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        
       
         if (other.gameObject.CompareTag("Bullet"))
        {
            health-= other.GetComponent<Bullet>().damage;
            
            if(health <= 0 ){

                 playerObject.GetComponent<Player>().points += points;
                 Destroy(gameObject);
            }
        }

        

        if(other.gameObject.CompareTag("Player"))
        {
            playerObject.GetComponent<Player>().damaged(collisionDamaged);
            Destroy(gameObject);
        }
       
    }
}
