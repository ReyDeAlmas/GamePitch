using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShot : MonoBehaviour
{
    public NormalShot shotOne;
    public NormalShot shotTwo;

    public bool isActive;

    public float elapsedTime;

    public float durationTime;

    void Start()
    {
        
        isActive = false;
        elapsedTime = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            shotOne.isActive = true;
            shotTwo.isActive = true;
           
            elapsedTime += Time.deltaTime;

            if(elapsedTime > durationTime)
            {
                isActive = false;
                shotOne.isActive = false;
                shotTwo.isActive = false;
                elapsedTime = 0;

            }


        }
    }
}
