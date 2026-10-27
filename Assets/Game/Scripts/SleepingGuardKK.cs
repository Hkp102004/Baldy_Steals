using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingGuardKK : MonoBehaviour
{
    [SerializeField] private GameObject StealingScene;
    void Start()
    {
        if(StealingScene == null)
        {
            Debug.LogError("you forgoit to add the stealing scene in '"+gameObject.name+"'");
            return;
        }

        StealingScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            StealingScene.SetActive(true);
        }
    }
}
