using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyesight : MonoBehaviour
{
    void OnTriggerEnter(Collider boom)
    {
        if(boom.gameObject.tag == "Player")
        {
            Debug.Log("Player is in the guard's sight"); //think this should do
        }
    }
}
