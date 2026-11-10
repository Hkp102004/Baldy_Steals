using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance {get; set;}
    [SerializeField] private GameObject startCutscene;

    public void Awake()
    {
        instance = this;
    }

    public static bool KeyCardBaby{get; set;}

    void Start()
    {
        if(startCutscene == null)
        {
            Debug.LogError("Start Cutscene is missing from GameManager");
            return;
        }

        startCutscene.SetActive(true); // to play the cutscene at start 
    }
}

