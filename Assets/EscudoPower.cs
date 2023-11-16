using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoPower : MonoBehaviour
{
    public bool shieldActive;

    public float time;

    public float duration;

    public GameObject currentObject;

    public CircleCollider2D circleCollider2D;

    public PlayerSettings settings;



    // Start is called before the first frame update
    void Start()
    {
        shieldActive = false;
        currentObject.GetComponent<Renderer>().enabled = false;
        circleCollider2D.enabled = false;
        time = 0;
        duration += settings.shieldDuration;
    }

    // Update is called once per frame
    void Update()
    {
       if(shieldActive)
       {
            time += Time.deltaTime;
            circleCollider2D.enabled = true;
            currentObject.GetComponent<Renderer>().enabled = true;

            if(time > duration)
            {
                shieldActive = false;
                time = 0;
                currentObject.GetComponent<Renderer>().enabled = false;
                circleCollider2D.enabled = false;
            }


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
