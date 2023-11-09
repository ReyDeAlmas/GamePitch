using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform limitOne;
    public Transform limitTwo;
    public Transform limitThree;
    public Transform limitFour;
    public Transform limitFive;
    public Transform limitSix;
    public Transform limitSeven;
    public Transform limitEight;
    public Transform limitNine;
    public Transform spawnSuicidaL;
    public Transform spawnSuicidaR;
    public Vector2 positionOne;
    public Vector2 positionTwo;
    public Vector2 positionThree;
    public Vector2 positionFour;
    public Vector2 positionFive;
    public Vector2 positionSix;
    public Vector2 positionSeven;
    public Vector2 positionEight;
    public Vector2 positionNine;
    public Vector2 positionSuicidaL;
    public Vector2 positionSuicidaR;

    public GameObject minion;
    public GameObject suicide;

    public float spawnInterval;

    public float spawnTime;

    public float spawnDuration;

    public float spawnTimeElapsed;

    public bool spawnEnabled;

    public float hordeSpawnInterval;

    public float hoderSpawnTime;

    public bool hordeIsSpawning;

    public int randomNumber;

    public int hordeCount;

    public int suicideQuantity;

    public int lastSuicideQuantity;

    public float suicideSpeed;

    


    // Start is called before the first frame update
    void Start()
    {
            positionOne = limitOne.position;
            positionTwo = limitTwo.position;
            positionThree = limitThree.position;
            positionFour = limitFour.position;
            positionFive = limitFive.position;
            positionSix = limitSix.position;
            positionSeven = limitSeven.position;
            positionEight =  limitEight.position; 
            positionNine =   limitNine.position;


            positionSuicidaL =  spawnSuicidaL.position; 
            positionSuicidaR =   spawnSuicidaR.position;


            spawnTime = 0;
            spawnTimeElapsed = 0;
            hoderSpawnTime = 0;
            spawnEnabled = true;
            hordeIsSpawning = true;

            randomNumber = Random.Range(1, 4);

            hordeCount = 1;

              lastSuicideQuantity = suicideQuantity;
         
    }

    // Update is called once per frame
    void Update()
    {
       

        if(!hordeIsSpawning)
        {
            hoderSpawnTime += Time.deltaTime;

            if(hoderSpawnTime > hordeSpawnInterval)
            {
                hordeIsSpawning = true;
                spawnEnabled = true;
                hoderSpawnTime = 0;
                randomNumber = Random.Range(1, 4);
                hordeCount++;
                
                if(hordeCount % 2 == 0)
                {
                     InvokeRepeating("spawnSuicide", 0.0f, 1);
                }

            }
        }


        if(spawnEnabled)
        {
             spawnTimeElapsed += Time.deltaTime;
             spawnTime += Time.deltaTime;

              if(spawnTime > spawnInterval)
             {
                 int speed = 3;
                 GameObject spawnedObject;
                 GameObject spawnedObjectTwo;
                 
                 
                switch (randomNumber)
                {
                    case 1:
                        spawnedObject = Instantiate(minion, positionOne, Quaternion.identity);
                        spawnedObjectTwo = Instantiate(minion, positionSeven, Quaternion.identity);
                        spawnedObject.GetComponent<EnemigoMinion>().speed = speed;
                        spawnedObject.GetComponent<EnemigoMinion>().leftLimit = limitOne;
                        spawnedObject.GetComponent<EnemigoMinion>().rightLimit = limitThree;
                        spawnedObjectTwo.GetComponent<EnemigoMinion>().speed = speed;
                        spawnedObjectTwo.GetComponent<EnemigoMinion>().leftLimit = limitSeven;
                        spawnedObjectTwo.GetComponent<EnemigoMinion>().rightLimit = limitNine;

                        break;
                    case 2:
                        spawnedObject = Instantiate(minion, positionOne, Quaternion.identity);
                        spawnedObject.GetComponent<EnemigoMinion>().speed = speed;
                        spawnedObject.GetComponent<EnemigoMinion>().leftLimit = limitOne;
                        spawnedObject.GetComponent<EnemigoMinion>().rightLimit = limitNine;
                        break;
                    case 3:
                        spawnedObject = Instantiate(minion, positionOne, Quaternion.identity);
                        spawnedObject.GetComponent<EnemigoMinion>().speed = speed;
                        spawnedObject.GetComponent<EnemigoMinion>().leftLimit = limitOne;
                        spawnedObject.GetComponent<EnemigoMinion>().rightLimit = limitNine;
                        break;
                    default:
                        Debug.Log("Número no válido");
                        break;
                }

                spawnTime = 0;
             }

            if(spawnTimeElapsed > spawnDuration)
            {
                spawnEnabled = false;
                hordeIsSpawning = false;
                spawnTimeElapsed = 0;
            }

           
        }
        
    }


 public void spawnSuicide()
    {
       

       GameObject spawnedObject = Instantiate(suicide, spawnSuicidaL.position, Quaternion.identity);
       spawnedObject.GetComponent<EnemigoSuicidad>().velocidad = suicideSpeed;

        suicideQuantity--;

        if (suicideQuantity <= 0)
        {
            CancelInvoke("spawnSuicide");
            suicideQuantity = lastSuicideQuantity + 2;
        }
    }
}

