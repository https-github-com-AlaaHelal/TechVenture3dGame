using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
   
    public GameObject StartMenuUI;
    public GameObject UI;



    private void Start()
    {
        Time.timeScale = 0f;
        StartMenuUI.SetActive(true);
    
     
    }

    public void StartTheGame()
    {

        StartMenuUI.SetActive(false);
        // to play the game back
        Time.timeScale = 1f;
        UI.SetActive(true);

    }

    public void QuitTheGame()

    {
        Debug.Log("QuitTheGame");
        Application.Quit();
    }




    public void exitcanvas()
    {

        StartMenuUI.SetActive(false);
    }




}