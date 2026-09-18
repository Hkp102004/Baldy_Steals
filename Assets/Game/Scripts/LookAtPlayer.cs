using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject StartPosition;
    [SerializeField] private Transform target;
    void Start()
    {
        Camera.main.transform.position = StartPosition.transform.position;
        Camera.main.transform.rotation = StartPosition.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
