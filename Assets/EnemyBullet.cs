using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;

    public float velocidadDisparo;

    public Rigidbody2D rb;

    

    void Start()
    {
      
        rb.AddForce(transform.right * velocidadDisparo, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
        private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador tocado!");
            other.GetComponent<Player>().damaged(damage);
            Destroy(gameObject);
        }
       
    }
}
