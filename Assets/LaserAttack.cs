using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public float targetSizeX;
    public float growthSpeed; // Ajusta la velocidad de crecimiento según tus necesidades

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(GrowCollider());
    }

    private System.Collections.IEnumerator GrowCollider()
    {
        float elapsedTime = 0f;
        float initialSizeX = boxCollider.size.x;

        while (elapsedTime < 2f)
        {
            float newSizeX = Mathf.Lerp(initialSizeX, targetSizeX, elapsedTime / 2f);
            boxCollider.size = new Vector2(newSizeX, boxCollider.size.y);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegúrate de establecer explícitamente el tamaño final una vez que se alcanza el tiempo deseado.
        boxCollider.size = new Vector2(targetSizeX, boxCollider.size.y);
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
