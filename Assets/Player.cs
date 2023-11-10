using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float health;
    public float endurance;

    public float points;

    public GameObject doubleShot;
    public GameObject shotShot;
    public GameObject laserAttack;
    public GameObject bombAttack;

    public GameObject escudo;

    public

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activePower(string powerType)
    {
        switch(powerType)
        {

            case "doubleShot":

                doubleShot.GetComponent<DoubleShot>().isActive = true;

                break;
            case "shotgunShot":

                shotShot.GetComponent<ShotgunShot>().isActive = true;

                break;
            case "laserAttack":

                laserAttack.GetComponent<LaserAttack>().isActive = true;

                break;
            case "bombAttack":

                bombAttack.GetComponent<BombaAtack>().isActive = true;

                break;

             case "escudo":

                escudo.GetComponent<EscudoPower>().shieldActive = true;

                break;

            default: 
                Debug.Log("Sin informacion del dropped");
                break;


        }
    }

    public void damaged(float damage){

       float damageTaken = damage - endurance;

        health -= damageTaken;


    }
}
