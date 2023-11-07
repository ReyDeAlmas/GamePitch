using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlackHole : MonoBehaviour
{

        
    public TouchMovement touchMovement;

    public GameObject player;

    public float attractionSpeed;

    public float timeOut;

    public bool isTrapped;

    public float time;
    // Start is called before the first frame update
    void Start()
    {
      isTrapped = false;  
      player =  GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        if(isTrapped)
        {

         if (player != null)
        {
            Vector2 targetPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 currentPosition = player.transform.position;
            player.transform.position = Vector2.MoveTowards(currentPosition, targetPosition, attractionSpeed * Time.deltaTime);
        }

            time += Time.deltaTime;

            if(time >= timeOut){
                isTrapped = false;
                touchMovement.isActive = true;
                Destroy(gameObject);
            }
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touchMovement.isActive = false;
            isTrapped = true;

        }
    }

    
}
