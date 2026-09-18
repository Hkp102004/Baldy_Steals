using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    void Start()
    {
        transform.Translate(1.06f,10.3f,6.12f); //initial position where the camera should be at the start of the game
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
