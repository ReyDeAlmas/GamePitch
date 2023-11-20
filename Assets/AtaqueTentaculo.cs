using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueTentaculo : MonoBehaviour
{
   // Referencia al objeto que deseas modificar
    public GameObject objetoX;

    // Tiempo total para la primera transición (en segundos)
    public float tiempoTotalPrimeraTransicion = 3f;

    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;

    // Opacidad normal cuando el BoxCollider2D está activo
    public float opacidadNormal = 1f;

    // Opacidad disminuida cuando el BoxCollider2D está desactivado
    public float opacidadDesactivado = 0.5f;

    public GameObject playerObject;

    public float collisionDamaged;

    // Escala objetivo después de la primera transición
    public Vector3 escalaObjetivoPrimeraTransicion = new Vector3(9f, 1f, 1f); // Ajusta según tus necesidades

    // Tiempo total para la segunda transición (en segundos)
    public float tiempoTotalSegundaTransicion = 3f;

    // Escala objetivo después de la segunda transición
    public Vector3 escalaObjetivoSegundaTransicion = new Vector3(0f, 1f, 1f); // Ajusta según tus necesidades

    // Método para cambiar el tamaño de ancho a 0 después de un retraso
    void Start()
    {
        Invoke("RealizarPrimeraTransicion", 3f);

        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
         // Verifica el estado del BoxCollider2D y ajusta la opacidad en consecuencia
        if (boxCollider.enabled)
        {
            // BoxCollider2D está activo, establece la opacidad normal
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, opacidadNormal);
        }
        else
        {
            // BoxCollider2D está desactivado, establece la opacidad disminuida
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, opacidadDesactivado);
        }
    }

    void RealizarPrimeraTransicion()
    {
          boxCollider.enabled = true;
        // Obtenemos la escala actual del objeto
        Vector3 escalaActual = objetoX.transform.localScale;

        // Establecemos el tamaño de ancho a 0, pero mantenemos la altura y la profundidad
        escalaActual.x = 0f;

        // Aplicamos la nueva escala al objeto
        objetoX.transform.localScale = escalaActual;

        // Inicia la primera transición
        StartCoroutine(RealizarTransicion(objetoX, escalaObjetivoPrimeraTransicion, tiempoTotalPrimeraTransicion, RealizarSegundaTransicion));
    }

    void RealizarSegundaTransicion()
    {
      
        // Inicia la segunda transición
        StartCoroutine(RealizarTransicion(objetoX, escalaObjetivoSegundaTransicion, tiempoTotalSegundaTransicion, DestruirObjeto));
    }

    IEnumerator RealizarTransicion(GameObject objeto, Vector3 escalaObjetivo, float tiempoTotal, System.Action onComplete)
    {
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < tiempoTotal)
        {
            tiempoTranscurrido += Time.deltaTime;

            float t = Mathf.Clamp01(tiempoTranscurrido / tiempoTotal);
            objeto.transform.localScale = Vector3.Lerp(objeto.transform.localScale, escalaObjetivo, t);

            yield return null;
        }

        // Llamamos a la acción onComplete después de completar la transición
        onComplete?.Invoke();
    }

    void DestruirObjeto()
    {
        // Destruye el objeto después de ambas transiciones
        Destroy(objetoX);
    }

          private void OnTriggerEnter2D(Collider2D other)
    {
        // Destruye el objeto después de ambas transiciones
         if(other.gameObject.CompareTag("Player"))
        {
            playerObject.GetComponent<Player>().damaged(collisionDamaged);
             Debug.Log(" Golpeado por tentaculo");
        }
    }

}
