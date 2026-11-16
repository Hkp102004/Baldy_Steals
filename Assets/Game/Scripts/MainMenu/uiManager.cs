using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
   private static uiManager instance;

   public static uiManager _instance
    {
        get
        {
            if(instance==null)
            {
                Debug.LogError("instance is missing in UImanager in main menu");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main"); //used for loading the main game scane in game;
    }

    public void QuitGame()
    {
        Application.Quit(); //used for quiting the game , wallah
    }
}
