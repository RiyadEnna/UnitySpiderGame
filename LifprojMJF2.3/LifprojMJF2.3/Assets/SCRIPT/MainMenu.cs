using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private string SceneToLoad;
    //public ParticleSystem p1;
    //public ParticleSystem p2;
    

    public GameObject MainMenuPauseUI; //fait r�f�rence � notre interface

    void Start()
    {
        MainMenuPauseUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        MainMenuPauseUI.SetActive(false);// disable our game object
        Time.timeScale = 1f; //create slow motion in game bc of 1f.
    }

    public void Option()
    {
        /*menuPauseUI.SetActive(true);// enable our game object
        Time.timeScale = 0f; //speed time wich time is passing 0 to completely freeze the game.
        GamePause = true;*/
    }

    public void Leave()
    {
        UnityEditor.EditorApplication.isPlaying = false; //donc le editor de jeu passe à false
        Application.Quit();
    }

    public void Return()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);    
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}