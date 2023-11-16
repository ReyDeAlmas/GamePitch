using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class PlayerData 
{


    public string playerName;
    public int playerHighScore;
    public float  currency;
    public float  attackBonus;

    public float increaseBonusAttackCost;

    public float  shieldDuration;
    public float  increaseBonusShieldCost;

    public float  armoredBonus;
    public float  increaseArmoredCost;

    public float  healthBonus;
    public float  increaseBonusHealthCost;

      public PlayerData()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
