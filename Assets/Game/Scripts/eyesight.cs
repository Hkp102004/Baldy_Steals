using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyesight : MonoBehaviour
{
    [SerializeField] private GameObject gameoverScene;
    private bool testing = true; //purely for testing purpose

    void Start()
    {
        if(gameoverScene == null)
        {
            Debug.LogError("Game over cutscene is missing in the eyesight script, one of it ");
            return;
        }
    }
    void OnTriggerEnter(Collider boom)
    {
        if(boom.gameObject.tag == "Player")
        {
            // Debug.Log("Player is in the guard's sight"); //think this should do
            if(!testing) //to test the other features for now
            {
                gameoverScene.SetActive(true);  
            }
        }
    }
}
