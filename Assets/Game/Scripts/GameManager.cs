using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance {get; set;}
    [SerializeField] private GameObject startCutscene;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraPosition;
    [SerializeField] private GameObject bgm;

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
        if(player == null)
        {
            Debug.LogError("Player is missing in GameManager");
            return;
        }
        if(cameraPosition == null)
        {
            Debug.LogError("Camra pos is missing in game manager");
            return;
        }
        if(bgm == null)
        {
            Debug.LogError("bgm is missing from GameManager");
            return;
        }

        startCutscene.SetActive(true); // to play the cutscene at start  //0.194
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            startCutscene.SetActive(false);
            player.SetActive(true);
            Camera.main.transform.position = cameraPosition.transform.position;
            Camera.main.transform.rotation = cameraPosition.transform.rotation;
            bgm.SetActive(true);
        }
    }
}

