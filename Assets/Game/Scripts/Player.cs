using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agentboy; //to access the navmesh agent
    private Vector3 destination; //to store the destination of the player yk
    [SerializeField] private Animator animator;

    void Start()
    {
        agentboy = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        if(agentboy == null)
        {
            Debug.LogError("NavMeshAgent is missing in player gameobj");
            return;
        }

        if(animator == null)
        {
            Debug.LogError("Animator component is missing in player gameobj");
            return;
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
                animator.SetBool("walk", true); //set the walking animation to true when the player is moving

                // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); //create a cube; //this was just to learn

                // cube.transform.position = hitinfo.point; //set the position of the cube to the point where the ray hit the object
                destination = hitinfo.point;

                // agentboy.destination = cube.transform.position; //set the destination of the agent to the where the ray hit the object and move the player to that position
                agentboy.SetDestination(hitinfo.point); // to move the player to the point where the ray hits the object
            }
        }

        float distance = Vector3.Distance(transform.position, destination); //ts will calculate the distance bw player & destination

        if(distance < 1.0f)
        {
            animator.SetBool("walk", false); 
        }
    }
}
