using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToSpawn;
    public bool isActive;
    public float speed;
    public float shotTime;

    public float time;
    public int setAngle;

    public float damage;

    void Start()
    {
        time = 0;
    }

   void Update () {

        time += Time.deltaTime;

        if(isActive&& shotTime < time)
          {
             
              GameObject obj = Instantiate(objectToSpawn, transform.position, Quaternion.Euler(0, 0, setAngle));
              Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

                        
            float angle =  -setAngle *  Mathf.Deg2Rad; 
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)); 

            
           if(angle != 0 )
           {
             rb.velocity = direction * speed; 
           }
           else{
             rb.velocity = Vector2.up * speed;
           }


            
            time = 0;
          }
    }

 
}
