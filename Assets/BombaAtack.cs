using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaAtack : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    public float targetRadius; // Ajusta el radio deseado aquí
    public float growthSpeed; // Calculado como (targetRadius - initialRadius) / 34

    public bool isActive;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        isActive = false;
    }


    private void Update()
    {
        if(isActive)
        {
               StartCoroutine(GrowCollider());
               isActive = false;
        }
    }
    
    private System.Collections.IEnumerator GrowCollider()
    {
        float elapsedTime = 0f;
        float initialRadius = 0;

        while (elapsedTime < 0.8f)
        {
            float newRadius = Mathf.Lerp(initialRadius, targetRadius, elapsedTime / 0.8f);
            circleCollider.radius = newRadius;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegúrate de establecer explícitamente el radio final una vez que se alcanza el tiempo deseado.
        circleCollider.radius = 0;
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
