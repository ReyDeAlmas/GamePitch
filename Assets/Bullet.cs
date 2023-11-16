using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;

    public PlayerSettings settings;

    public GameObject gameManager;

    void Start()
    {

         gameManager = GameObject.FindGameObjectWithTag("GameManager");

        if (gameManager != null)
        {
            
            settings = gameManager.GetComponent<PlayerSettings>();
            

            if (settings != null)
            {
                damage += settings.attackBonus;
            }
            else
            {
                Debug.LogError("No se encontró el componente PlayerSettings en el GameManager.");
            }
        }
        else
        {
            Debug.LogError("No se encontró el GameManager.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
