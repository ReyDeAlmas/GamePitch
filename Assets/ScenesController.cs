using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{

    public GameObject hud;
    public GameObject gameOver;
    public GameObject start;
    public GameObject options;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public void loadSceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }

          public void loadSceneGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

     public void load()
    {
        SceneManager.LoadScene("Stats");
            resumeScene();
    }



     public void RestartScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        resumeScene();
    }


    public void pauseScene()
    {
        Time.timeScale = 0;
        
    }
    public void resumeScene()
    {
        Time.timeScale = 1 ; 
    }


    public void toogleHUD(){
        hud.SetActive(!hud.activeSelf);
    }

     public void toogleStart(){
        start.SetActive(!start.activeSelf);
    }

      public void toogleOptions(){
        options.SetActive(!options.activeSelf);
    }

      public void toogleGameOver(){
        gameOver.SetActive(!gameOver.activeSelf);
    }

    public void showSettings(){
        toogleStart();
        toogleOptions();
    }
}
