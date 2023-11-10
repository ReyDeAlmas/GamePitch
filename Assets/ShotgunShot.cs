using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShot : MonoBehaviour
{
    // Start is called before the first frame update

    public NormalShot shotOne;
    public NormalShot shotTwo;
    public NormalShot shotThree;

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
            shotThree.isActive = true;

            elapsedTime += Time.deltaTime;

            if(elapsedTime > durationTime)
            {
                isActive = false;
                shotOne.isActive = false;
                shotTwo.isActive = false;
                shotThree.isActive = false;
                elapsedTime = 0;

            }


        }
    }
}
