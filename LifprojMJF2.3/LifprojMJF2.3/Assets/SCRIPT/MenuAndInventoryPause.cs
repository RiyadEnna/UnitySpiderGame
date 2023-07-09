using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAndInventoryPause : MonoBehaviour
{
    private string SceneToLoad;
    public GameObject menuPauseUI; //fait r�f�rence � notre interface
    public GameObject InventoryUI;

    //pour enable le script
    public GameObject Player;
    
    void Start()
    {
        menuPauseUI.SetActive(false);
        InventoryUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuPauseUI.activeSelf)
            {
                Resume();
                Cursor.visible = false;
            }
            else
            {
                Pause();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(InventoryUI.activeSelf)
            {
                DesactiveInventory();
                Cursor.visible = false;
            }
            else
            {
                ActiveInventory();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Player.GetComponent<TristaScriptMoveBasic>().enabled = true;
        Debug.Log("oke Resume");
        menuPauseUI.SetActive(false);// disable our game object
        Time.timeScale = 1f; //create slow motion in game bc of 1f.
    }

    public void Pause()
    {
        Player.GetComponent<TristaScriptMoveBasic>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("oke Pause");
        menuPauseUI.SetActive(true);// enable our game object
        Time.timeScale = 0f; //speed time wich time is passing 0 to completely freeze the game.
        if(InventoryUI.activeSelf)
        {
            menuPauseUI.SetActive(true);
            InventoryUI.SetActive(false);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("menu");
    }

    public void ActiveInventory()
    {
        Player.GetComponent<TristaScriptMoveBasic>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        InventoryUI.SetActive(true);
        Time.timeScale = 0f;
        if(menuPauseUI.activeSelf)
        {
            InventoryUI.SetActive(true);
            menuPauseUI.SetActive(false);
        }
    }

    public void DesactiveInventory()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Player.GetComponent<TristaScriptMoveBasic>().enabled = true;
        InventoryUI.SetActive(false);
        Time.timeScale = 1f;
    }
}