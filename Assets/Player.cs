using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float health;
    public float endurance;

    public float points;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damaged(float damage){

       float damageTaken = damage - endurance;

        health -= damageTaken;


    }
}
