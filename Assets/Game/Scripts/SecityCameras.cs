using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SecityCameras : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject GameOverScene; //gameover ctscne
    [SerializeField] private Material Emergency_Light;
    private MeshRenderer Renderboy; //this is the mesh renderer
    [SerializeField] private GameObject Camera;
    private Animator animator;
    void Start()
    {
        Renderboy = GetComponent<MeshRenderer>(); //to get the mesh renderer to change material when needed
        animator = Camera.GetComponent<Animator>(); //to get the animator of their specific cameras

        if(GameOverScene == null)
        {
            Debug.LogError("GameOver Cutscene is missing from SecurityCamera Script");
            return;
        }
        if(Renderboy == null)
        {
            Debug.LogError("Something is wrong, Render girlie didn't work in "+ gameObject.name +"!!!!!");
            return;
        }
        if(Emergency_Light == null)
        {
            Debug.LogError("Emergy light is missing in "+ gameObject.name +".");
            return;
        }
        if(Camera == null)
        {
            Debug.LogError("Camera Parent is missing in "+gameObject.name+".");
            return;
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
            animator.speed = 0; // to stop the animation or something likr that
            Caught();
            Renderboy.material = Emergency_Light; //not maybe , this actually works. yaay
            GameOverScene.SetActive(true); //used to start the gameover scene
        }
    }


    IEnumerator Caught()
    {
        yield return new WaitForSeconds(2f);
    }
    
}
