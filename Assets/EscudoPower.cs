using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoPower : MonoBehaviour
{
    public bool isActive;

    public float time;

    public float duration;

    public GameObject currentObject;

    public CircleCollider2D circleCollider2D;



    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        currentObject.GetComponent<Renderer>().enabled = true;
        circleCollider2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > duration)
        {

            isActive = false;
            time = 0;
             currentObject.GetComponent<Renderer>().enabled = false;
                  circleCollider2D.enabled = false;

        }
    }
    
   private void OnTriggerEnter2D(Collider2D other)
    {
        
      
         if (other.gameObject.CompareTag("Enemy")||other.gameObject.CompareTag("EnemyBullet"))
        {
             Destroy(other.gameObject);
        }
       
    }

    
}
