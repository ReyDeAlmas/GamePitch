using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideSpawnMovement : MonoBehaviour
{
   
    public Transform startPoint;
    public Transform endPoint;
    public float speed;
  
    private  bool limitPass;



    // Start is called before the first frame update
    void Start()
    {
       
       
        limitPass = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if(limitPass){
              transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else{
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
       
        if(transform.position.y <= startPoint.position.y)
        {
          limitPass = true;
        }

         if(transform.position.y >= endPoint.position.y)
        {
            limitPass = false;
        }      

        
    }
}
