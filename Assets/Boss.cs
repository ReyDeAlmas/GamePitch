using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update

    public float statement;

    public GameObject spawnLeft;

    public GameObject spawnRight;

    public bool spawnActive;

    public GameObject bulletLeft;
    public GameObject bulletRight;

    public GameObject spawnSpinnerLeft;
    public GameObject spawnSpinnerRight;


    public GameObject tentaculo;

    public GameObject spinner;

    public float time;

    public float timeElapsed;

    public float spawnBulletInterval;

    public float spawnBulletTime;

    public float timeActive;

    public float timeActiveElapsed;

    public bool spawnSpinner;


    void Start()
    {
          spawnActive = true;
          spawnSpinner = true;
          spawnLeft = GameObject.FindGameObjectWithTag("BossBulletOne");
          spawnRight = GameObject.FindGameObjectWithTag("BossBulletTwo");
          spawnSpinnerLeft= GameObject.FindGameObjectWithTag("SpawnLeftSucide");
          spawnSpinnerRight = GameObject.FindGameObjectWithTag("SpawnRightSucide");
    }

    // Update is called once per frame
    void Update()
    {
       

        if(timeActiveElapsed > timeActive)
        {
            spawnActive = true;
            spawnSpinner = true;
            timeActiveElapsed = 0;
        }


         if (spawnActive)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed < time)
            {

                spawnBulletTime += Time.deltaTime;


                if (spawnBulletTime > spawnBulletInterval)
                {
                    
                    Instantiate(bulletLeft, spawnLeft.transform.position, spawnLeft.transform.rotation);
                    Instantiate(bulletRight, spawnRight.transform.position, spawnRight.transform.rotation);


                    

                    // Utiliza un switch para manejar cada caso
                    

                    if(spawnSpinner)
                    {

                         int valorRandom = Random.Range(1, 3);

                        switch (valorRandom)
                    {
                        case 1:
                           Instantiate(tentaculo, spawnLeft.transform.position, spawnLeft.transform.rotation);
                            // Código para el caso 1
                            break;

                        case 2:
                          Instantiate(tentaculo, spawnRight.transform.position, spawnRight.transform.rotation);
                            // Código para el caso 2
                            break;

                        default:
                            Debug.Log("El valor randomizado está fuera del rango esperado.");
                            // Código para otros casos (si es necesario)
                            break;
                    }

                        Instantiate(spinner, spawnSpinnerLeft.transform.position, spawnSpinnerLeft.transform.rotation);
                        Instantiate(spinner, spawnSpinnerRight.transform.position, spawnSpinnerRight.transform.rotation);
                        spawnSpinner = false;
                    }

                    spawnBulletTime = 0;
                }
            }
            else
            {
                // Reiniciar el temporizador y desactivar el spawn después de alcanzar el tiempo total
                timeElapsed = 0;
                spawnActive = false;
            }
        }else{
             timeActiveElapsed += Time.deltaTime;

        }
    }
}
