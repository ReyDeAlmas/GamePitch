using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falldown : MonoBehaviour
{
    // Start is called before the first frame update
      public float fallSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }
}
