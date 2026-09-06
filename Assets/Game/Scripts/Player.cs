using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent agentboy;
    void Start()
    {
        agentboy = GetComponent<NavMeshAgent>();
        if(agentboy == null)
        {
            Debug.LogError("NavMeshAgent agentboy is not attacked to Player gameobj");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //for left mouse button
        {
            //to cast a ray from camera to mouse position
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo; // stores the information of the object that is hit by the ray

            if(Physics.Raycast(rayOrigin, out hitinfo)) // if the ray hits an object
            {
                Debug.Log(hitinfo.point); // prints the point where the ray hits the object

                // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); //create a cube; //this was just to learn

                // cube.transform.position = hitinfo.point; //set the position of the cube to the point where the ray hit the object

                // agentboy.destination = cube.transform.position; //set the destination of the agent to the where the ray hit the object and move the player to that position
                agentboy.SetDestination(hitinfo.point);
            }
        }
    }
}
