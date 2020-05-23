using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    private void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    void Update()
    {   //when player press f1 the menu appear
        if (Input.GetKeyDown(KeyCode.F1))

        {
            if (GameIsPaused)
            { Resume(); }

            else
            { Pause(); }

        }
    }

    public void Resume()
    {

        PauseMenuUI.SetActive(false);
        // to play the game back
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        // to freeze thee game
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

   //function to load the main menu 
    public void LoadMenu()

    {     
      SceneManager.LoadScene("EmptyScene"); }

    public void QuitGame()

    { Application.Quit(); }


}
