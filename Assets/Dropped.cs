using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropped : MonoBehaviour
{


    // Start is called before the first frame update

    public GameObject playerObject;
    public Player player;

    public string powerName;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); 
        player = playerObject.GetComponent<Player>();  
    }


    // Update is called once per frame
    void Update()
    {
        
    }


      void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            other.GetComponent<Player>().activePower(powerName);
            Destroy(gameObject);

           
        }
    }
}
