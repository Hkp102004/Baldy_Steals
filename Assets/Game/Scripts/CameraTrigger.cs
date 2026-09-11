using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Transform positionCamera; //the transform of the camera which position will set to main camera

    void Start()
    {
        if(positionCamera == null)
        {
            Debug.LogError("Position camera is missing in " + gameObject.name);
            return;
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Camera.main.transform.position = positionCamera.transform.position;
            Camera.main.transform.rotation = positionCamera.transform.rotation;
        }

    }
}
