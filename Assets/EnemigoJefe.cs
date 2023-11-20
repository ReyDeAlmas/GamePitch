using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoJefe : MonoBehaviour
{
    public float health;

    public float collisionDamaged;

    public float points;
    public GameObject playerObject;

    public GameManager gameManager;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
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

                
                gameManager.bosDefeated();


                 playerObject.GetComponent<Player>().points += points;

                 Destroy(gameObject);
            }
        }

        

        if(other.gameObject.CompareTag("Player"))
        {
            playerObject.GetComponent<Player>().damaged(collisionDamaged);
          
        }
       
    }
}
