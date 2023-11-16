using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;



public class PlayerSettings : MonoBehaviour
{
    // Start is called before the first frame update

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

      public TextMeshProUGUI currencyText;


     public TextMeshProUGUI attackText;

     public TextMeshProUGUI shieldText;

     public TextMeshProUGUI armoredText;

     public TextMeshProUGUI healthText;

     public TextMeshProUGUI attackCostText;

     public TextMeshProUGUI shieldCostText;

     public TextMeshProUGUI armoredCostText;

     public TextMeshProUGUI healthCostText;

     public bool isMenuScene;

     public string filePath;
     

    public PlayerData playerData;


    void Start()
        {

         filePath = "Assets/playerData.json"; 
          string playerDataJson = "";

        // Lee el contenido del archivo
        try
        {
            playerDataJson = File.ReadAllText(filePath);
        }
        catch (IOException e)
        {
            Debug.LogError("Error al leer el archivo JSON: " + e.Message);
            return;
        }

        
        playerData = JsonUtility.FromJson<PlayerData>(playerDataJson);


        playerName = playerData.playerName;
        playerHighScore = playerData.playerHighScore;
        currency = playerData.currency;
        attackBonus = playerData.attackBonus;
        shieldDuration = playerData.shieldDuration;
        armoredBonus = playerData.armoredBonus;
        healthBonus = playerData.healthBonus;
        increaseBonusAttackCost = playerData.increaseBonusAttackCost;
        increaseBonusShieldCost = playerData.increaseBonusShieldCost;
        increaseArmoredCost = playerData.increaseArmoredCost;
        increaseBonusHealthCost = playerData.increaseBonusHealthCost;



    }
    // Update is called once per frame
    void Update()
    {
        if(isMenuScene)
       {
        
        currencyText.text = currency.ToString();
         attackText.text = attackBonus.ToString();
         shieldText.text = shieldDuration.ToString();
         armoredText.text = armoredBonus.ToString();
         healthText.text = healthBonus.ToString();
 
         attackCostText.text = increaseBonusAttackCost.ToString();
         shieldCostText.text = increaseBonusShieldCost.ToString();
         armoredCostText.text = increaseArmoredCost.ToString();
         healthCostText.text = increaseBonusHealthCost.ToString();
       }
    }





    public void setSetting()
    {
          
          playerData.playerName = playerName;
          playerData.playerHighScore = playerHighScore;
          playerData.currency = currency;
          playerData.attackBonus = attackBonus;
          playerData.shieldDuration = shieldDuration;
          playerData.armoredBonus = armoredBonus;
          playerData.healthBonus = healthBonus;
          playerData.increaseBonusAttackCost = increaseBonusAttackCost;
          playerData.increaseBonusShieldCost = increaseBonusShieldCost;
          playerData.increaseArmoredCost = increaseArmoredCost;
          playerData.increaseBonusHealthCost = increaseBonusHealthCost;

          string json = JsonUtility.ToJson(playerData);
          File.WriteAllText(filePath, json);
        

          Debug.Log("Cambios realizados");

    }

    public void cancelChanges()
    {
        string playerDataJson = File.ReadAllText(filePath);
        playerData = JsonUtility.FromJson<PlayerData>(playerDataJson);
        playerName = playerData.playerName;
        playerHighScore = playerData.playerHighScore;
        currency = playerData.currency;
        attackBonus = playerData.attackBonus;
        shieldDuration = playerData.shieldDuration;
        armoredBonus = playerData.armoredBonus;
        healthBonus = playerData.healthBonus;
        increaseBonusAttackCost = playerData.increaseBonusAttackCost;
        increaseBonusShieldCost = playerData.increaseBonusShieldCost;
        increaseArmoredCost = playerData.increaseArmoredCost;
        increaseBonusHealthCost = playerData.increaseBonusHealthCost;
         Debug.Log("Cambios cancelados");
    }

    public bool checkCurrency(float cost)
    {
        if(currency - cost >= 0)
        {
            currency -= cost;
            return true;
        }

        return false;
    }

    public void attackIncrease()
    {

        if(checkCurrency(increaseBonusAttackCost))
        {
            increaseBonusAttackCost = increaseBonusAttackCost*2;
            playerData.increaseBonusAttackCost =  playerData.increaseBonusAttackCost*2;
            attackBonus+=1;
            playerData.attackBonus += 1;
        }
        else{
            Debug.Log("Sin dinero suficiente");
        }
    }

      public void shiledIncrese()
    {


        if(checkCurrency(increaseBonusShieldCost))
        {
            increaseBonusShieldCost = increaseBonusShieldCost*2;
            playerData.increaseBonusShieldCost =  playerData.increaseBonusShieldCost*2;
            shieldDuration+=1;
            playerData.shieldDuration += 1;
        }
        else{
            Debug.Log("Sin dinero suficiente");
        }
    }


        public void armorIncrease()
    {


        if(checkCurrency(increaseArmoredCost))
        {
            increaseArmoredCost = increaseArmoredCost*2;
            playerData.increaseArmoredCost =  playerData.increaseArmoredCost*2;
            armoredBonus+=1;
            playerData.armoredBonus += 1;
        }
        else{
            Debug.Log("Sin dinero suficiente");
        }
    }


    public void healthIncrease()
    {


        if(checkCurrency(increaseBonusHealthCost))
        {
            increaseBonusHealthCost = increaseBonusHealthCost*2;
            playerData.increaseBonusHealthCost =  playerData.increaseBonusHealthCost*2;
            healthBonus+=1;
            playerData.healthBonus += 1;
        }
        else{
            Debug.Log("Sin dinero suficiente");
        }
    }




}

