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
    public GameObject metheor;
    public GameObject blackhole;

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
    public int metheorQuantity;
    public int lastMetheorQuantity;

    public float suicideSpeed; 
    public float metheorSpeed; 
    public float blackholeSpeed; 

    public float speedMinionOne;
    public float speedMinionTwo;
    public float speedMinionThree;

    //Droppeds
    public GameObject doubleShot;
    public GameObject shotShot;
    public GameObject laserAttack;
    public GameObject bombAttack;

    public GameObject escudo;


    public GameObject boss;
    public GameObject bossSpawn;

    public bool isBossTime;
    public bool isBossSpawned;

    

    


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

            randomNumber = Random.Range(1, 6);

            hordeCount = 1;

            isBossTime = false;

            isBossSpawned =true;



             
         
    }

    // Update is called once per frame
    void Update()
    {
        
       

        if(isBossTime){
             
          

             if(isBossSpawned)
             {  
                Debug.Log("Spawneando boss");
                Instantiate(boss, bossSpawn.transform.position, Quaternion.identity);
                isBossSpawned = false; 
             }
        }


        if(!isBossTime)
        {
            

        if(!hordeIsSpawning)
        {
            hoderSpawnTime += Time.deltaTime;

            if(hoderSpawnTime > hordeSpawnInterval)
            {   
                hordeCount++;
                hordeIsSpawning = true;
                spawnEnabled = true;
                hoderSpawnTime = 0;
                randomNumber = Random.Range(1, 6);
               
                
                hordeSpawnInterval *= 0.98f;
                spawnInterval *= 0.98f;
                spawnDuration += 0.1f;

                speedMinionOne *= 1.02f;
                speedMinionTwo *= 1.02f;
                speedMinionThree *= 1.02f;




                lastSuicideQuantity = suicideQuantity;
                lastMetheorQuantity = metheorQuantity;



                spawnDropped();

                if(hordeCount % 2 == 0)
                    {
                        InvokeRepeating("spawnSuicide", 0.0f, 1);
                    }

                     if(hordeCount % 3 == 0 && hordeCount >= 5)
                    {
                        InvokeRepeating("spawnMetheor", 0.0f, 1);
                    }

                       if(hordeCount % 1 == 0 && hordeCount >= 8)
                    {
                       blackholeSpawn();
                    }
                
            }
        }


        if(spawnEnabled)
        {
             spawnTimeElapsed += Time.deltaTime;
             spawnTime += Time.deltaTime;

              if(spawnTime > spawnInterval)
             {
                
                 GameObject spawnedObject;
                 GameObject spawnedObjectTwo;
                 
                 
                switch (randomNumber)
                {
                    case 1:
                        spawnedObject = Instantiate(minion, positionOne, Quaternion.identity);
                        spawnedObjectTwo = Instantiate(minion, positionSeven, Quaternion.identity);
                        spawnedObject.GetComponent<EnemigoMinion>().speed = speedMinionOne;
                        spawnedObjectTwo.GetComponent<EnemigoMinion>().speed = speedMinionOne;
                        spawnedObject.GetComponent<EnemigoMinion>().leftLimit = limitOne;
                        spawnedObject.GetComponent<EnemigoMinion>().rightLimit =limitThree;
                        spawnedObjectTwo.GetComponent<EnemigoMinion>().leftLimit = limitSeven;
                        spawnedObjectTwo.GetComponent<EnemigoMinion>().rightLimit = limitNine;

                        break;
                    case 2:
                        spawnedObject = Instantiate(minion, positionOne, Quaternion.identity);
                        spawnedObject.GetComponent<EnemigoMinion>().speed = speedMinionTwo;
                        spawnedObject.GetComponent<EnemigoMinion>().leftLimit = limitOne;
                        spawnedObject.GetComponent<EnemigoMinion>().rightLimit = limitNine;
                        break;
                    case 3:
                        spawnedObject = Instantiate(minion, positionOne, Quaternion.identity);
                        spawnedObject.GetComponent<EnemigoMinion>().speed = speedMinionThree;
                        spawnedObject.GetComponent<EnemigoMinion>().leftLimit = limitOne;
                        spawnedObject.GetComponent<EnemigoMinion>().rightLimit = limitNine;
                        break;

                    case 4:
                        spawnedObject = Instantiate(minion, positionOne, Quaternion.identity);
                        spawnedObject.GetComponent<EnemigoMinion>().speed = speedMinionThree;
                        spawnedObject.GetComponent<EnemigoMinion>().leftLimit = limitOne;
                        spawnedObject.GetComponent<EnemigoMinion>().rightLimit = limitFive;
                    break;

                    case 5:
                        spawnedObject = Instantiate(minion, positionOne, Quaternion.identity);
                        spawnedObject.GetComponent<EnemigoMinion>().speed = speedMinionThree;
                        spawnedObject.GetComponent<EnemigoMinion>().leftLimit = limitFive;
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
                     if(hordeCount % 14 == 0)
                        {
                            isBossTime = true;
                        }
                    spawnTimeElapsed = 0;
                }

           
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


            

             if(suicideQuantity < 4)
           {
              suicideQuantity = lastSuicideQuantity + 1;
           }

        }
    }


    public void blackholeSpawn()
    {
       

        int randomSpawn = Random.Range(3, 7);
         GameObject spawnedObject = null;

         switch (randomSpawn)
        {
            case 3:    spawnedObject = Instantiate(blackhole, limitThree.position, Quaternion.identity);; break;
            case 4:    spawnedObject = Instantiate(blackhole, limitFour.position, Quaternion.identity);; break;
            case 5:    spawnedObject = Instantiate(blackhole, limitFive.position, Quaternion.identity);; break;
            case 6:    spawnedObject = Instantiate(blackhole, limitSix.position, Quaternion.identity);; break;
            default:    spawnedObject = Instantiate(blackhole, limitTwo.position, Quaternion.identity);; break;

        }
   
    }


    public void spawnMetheor()
    {
       
        int randomSpawn = Random.Range(1, 10);
         GameObject spawnedObject = null;

         switch (randomSpawn)
        {
            
            case 1:    spawnedObject = Instantiate(metheor, limitOne.position, Quaternion.identity);;  break;
            case 2:    spawnedObject = Instantiate(metheor, limitTwo.position, Quaternion.identity);; break;
            case 3:    spawnedObject = Instantiate(metheor, limitThree.position, Quaternion.identity);; break;
            case 4:    spawnedObject = Instantiate(metheor, limitFour.position, Quaternion.identity);; break;
            case 5:    spawnedObject = Instantiate(metheor, limitFive.position, Quaternion.identity);; break;
            case 6:    spawnedObject = Instantiate(metheor, limitSix.position, Quaternion.identity);; break;
            case 7:    spawnedObject = Instantiate(metheor, limitSeven.position, Quaternion.identity);; break;
            case 8:    spawnedObject = Instantiate(metheor, limitEight.position, Quaternion.identity);; break;
            case 9:    spawnedObject = Instantiate(metheor, limitNine.position, Quaternion.identity);; break;

        }

      
       spawnedObject.GetComponent<Falldown>().fallSpeed = metheorSpeed;

        metheorQuantity--;
        Debug.Log("Spawneado"+randomSpawn.ToString());

        if (metheorQuantity <= 0)
        {

            CancelInvoke("spawnMetheor");
           
           if(metheorQuantity < 5)
           {
             metheorQuantity = lastMetheorQuantity + 1;
           }
        }
    }


    public void spawnDropped()
    {
        GameObject dropped = null;
        int randomObject = Random.Range(1, 6);

        switch(randomObject)
        {
            case 1:
                dropped = doubleShot;
            break;
            case 2:
                dropped = shotShot;
            break;
            case 3:
                dropped = laserAttack;
            break;
            case 4:
                dropped = bombAttack;
            break;
            case 5:
                dropped = escudo;
            break;
        }

        int randomSpawn = Random.Range(1, 10);
        GameObject spawnedObject = null;

         switch (randomSpawn)
        {
            case 1:    spawnedObject = Instantiate(dropped, limitOne.position, Quaternion.identity);;  break;
            case 2:    spawnedObject = Instantiate(dropped, limitTwo.position, Quaternion.identity);; break;
            case 3:    spawnedObject = Instantiate(dropped, limitThree.position, Quaternion.identity);; break;
            case 4:    spawnedObject = Instantiate(dropped, limitFour.position, Quaternion.identity);; break;
            case 5:    spawnedObject = Instantiate(dropped, limitFive.position, Quaternion.identity);; break;
            case 6:    spawnedObject = Instantiate(dropped, limitSix.position, Quaternion.identity);; break;
            case 7:    spawnedObject = Instantiate(dropped, limitSeven.position, Quaternion.identity);; break;
            case 8:    spawnedObject = Instantiate(dropped, limitEight.position, Quaternion.identity);; break;
            case 9:    spawnedObject = Instantiate(dropped, limitNine.position, Quaternion.identity);; break;
        }
    }

    public void bosDefeated()
    {
        isBossTime = false;
        isBossSpawned = true;
    }


}







