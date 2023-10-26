using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    public float destroyTime;
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time +=  Time.deltaTime;

        if( time > destroyTime)
        {
             Destroy(gameObject);
        }

        
    }
}
