using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public float targetSizeX;
    public float growthSpeed; // Ajusta la velocidad de crecimiento según tus necesidades

    public SpriteRenderer laserAnimacion; 

    public bool isActive;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        isActive = false;
        laserAnimacion.enabled = false;
       
    }

    private void Update()
    {
        if(isActive)
        {
             StartCoroutine(GrowCollider());
             isActive = false;
             laserAnimacion.enabled = true;
        }

        
    }


    public System.Collections.IEnumerator GrowCollider()
    {
        float elapsedTime = 0f;
        float initialSizeX = 0;

        while (elapsedTime < 2f)
        {
            float newSizeX = Mathf.Lerp(initialSizeX, targetSizeX, elapsedTime / 2f);
            boxCollider.size = new Vector2(newSizeX, boxCollider.size.y);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        boxCollider.size = new Vector2(0, boxCollider.size.y);
        laserAnimacion.enabled = false;
    }

       void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("colisionando");
            Destroy(other.gameObject);
        }
    }
}
