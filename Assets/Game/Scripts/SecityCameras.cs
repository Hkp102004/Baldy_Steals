using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecityCameras : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject GameOverScene;
    void Start()
    {
        if(GameOverScene == null)
        {
            Debug.LogError("GameOver Cutscene is missing from SecurityCamera Script");
        }

        GameOverScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameOverScene.SetActive(true); //used to start the gameover scene
        }
    }
}
