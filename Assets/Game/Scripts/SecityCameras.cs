using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecityCameras : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject GameOverScene; //gameover ctscne
    [SerializeField] private Material Emergency_Light;
    private MeshRenderer Renderboy; //this is the mesh renderer
    void Start()
    {
        Renderboy = GetComponent<MeshRenderer>();

        if(GameOverScene == null)
        {
            Debug.LogError("GameOver Cutscene is missing from SecurityCamera Script");
        }
        if(Renderboy == null)
        {
            Debug.LogError("Something is wrong, Render boy didn't do his work!!!!");
        }

        GameOverScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Emergency_Light)
            {
                Renderboy.material = Emergency_Light; //not maybe , this actually works. yaay
            }
            GameOverScene.SetActive(true); //used to start the gameover scene
        }
    }
}
