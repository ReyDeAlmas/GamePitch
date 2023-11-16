using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDMannagger : MonoBehaviour
{
    // Start is called before the first frame update

     public TextMeshProUGUI pointsText;

     public TextMeshProUGUI healthText;

     public TextMeshProUGUI finalPointText;
     public TextMeshProUGUI highestPointsText;
     public TextMeshProUGUI cristalesText;

      

     public Player player;

     public float points;

     public float health;

     public float highestPoints;

     public int cristales;

     public PlayerSettings settings;

    void Start()
    {

        highestPoints = settings.playerHighScore;
        cristales  = 0;


    }

    // Update is called once per frame
    void Update()
    {
        

        points = player.points;
        health =  player.health;
        healthText.text = health.ToString();
        pointsText.text = points.ToString("0000");
        finalPointText.text = points.ToString("0000");
        highestPointsText.text = highestPoints.ToString("0000");
        cristalesText.text = cristales.ToString("0");

    }


    public void setCristales()
    {
         cristales = Mathf.FloorToInt((float)points / 10f);
    }

    public void setJson()
    {
        settings.currency += cristales;
        
        if(points >  settings.playerHighScore)
        {
            settings.playerHighScore = Mathf.FloorToInt(points);
        }

        settings.setSetting();

    }

}
