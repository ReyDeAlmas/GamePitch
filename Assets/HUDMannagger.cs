using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDMannagger : MonoBehaviour
{
    // Start is called before the first frame update

     public TextMeshProUGUI pointsText;

     public TextMeshProUGUI healthText;

     public Player player;

     public float points;

     public float health;

    void Start()
    {

        


    }

    // Update is called once per frame
    void Update()
    {
        
        points = player.points;
        health =  player.health;

        healthText.text = health.ToString();
        pointsText.text = points.ToString("0000");

    }
}
