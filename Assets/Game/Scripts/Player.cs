using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agentboy; //to access the navmesh agent
    private Vector3 destination; //to store the destination of the player yk
    [SerializeField] private GameObject coin; //this is the coin that will be used to distract guards
    [SerializeField] private Animator animator;
    [SerializeField] private Transform CoinFolder;
    [SerializeField] private float coinRange = 10;
    private bool isMoving = false;
    private float coinCount=2;

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
        if(coin == null)
        {
            Debug.LogError("coin gameobj is missing from player");
            return;
        }
        if(CoinFolder == null)
        {
            Debug.LogError("coin folder is missing in player Script");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //for left mouse button / movement of player
        {
            //to cast a ray from camera to mouse position
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo; // stores the information of the object that is hit by the ray

            if(Physics.Raycast(rayOrigin, out hitinfo)) // if the ray hits an object
            {

                // *****OLD CODES*****
                // Debug.Log(hitinfo.point); // prints the point where the ray hits the object
                // animator.SetBool("walk", true); //set the walking animation to true when the player is moving
                // animator.SetTrigger("walking"); //using trigger method to switch bw animations instead
                // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); //create a cube; //this was just to learn
                // cube.transform.position = hitinfo.point; //set the position of the cube to the point where the ray hit the object
                // agentboy.destination = cube.transform.position; //set the destination of the agent to the where the ray hit the object and move the player to that position
                // agentboy.SetDestination(hitinfo.point); // to move the player to the point where the ray hits the object

                //someting new and better I hope


                destination = hitinfo.point;

                if(agentboy.SetDestination(destination))
                {
                    isMoving = true;

                    animator.ResetTrigger("going idle");
                    animator.SetTrigger("walking");
                }
            }
        }

        if(Input.GetMouseButtonDown(1)) //coin distraction logic / right mouse button
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;

            if(Physics.Raycast(rayOrigin, out hitinfo))
            {
                Vector3 location = new Vector3(hitinfo.point.x, -1.8f , hitinfo.point.z);

                float coinDistance = Vector3.Distance(transform.position , location);

                if(coinDistance <= coinRange)  //to make sure the player can not throw coin too far
                {
                    if(coinCount > 0 )
                    {
                        animator.SetTrigger("throw");
                        GameObject SpawnedCoin = Instantiate(coin, location, Quaternion.identity);
                        SpawnedCoin.transform.SetParent(CoinFolder);
                        coinCount --;
                        SecurityDistaction(location);
                        StartCoroutine(CoinCountDown(5));
                    }
                }
            }
        }
        

        //maybe let's give it a try ***************NEW CODES*********
        if(isMoving && !agentboy.pathPending)
        {
            bool reachedDestination = agentboy.remainingDistance <= agentboy.stoppingDistance + 0.1f;

            bool stopped = agentboy.velocity.sqrMagnitude < 0.01f;

            if(reachedDestination && stopped)
            {
                isMoving = false;
                animator.ResetTrigger("walking");
                animator.SetTrigger("going idle");
            }
        }
    }


    void SecurityDistaction(Vector3 position) //coin distraction function to contact with GuardAI
    {
        if(position != null)
        {
            // guardScript.Distraction(position);
            GameObject[] Guards = GameObject.FindGameObjectsWithTag("Guard1");

            foreach(var guard in Guards)
            {
                GuardAI guardScript = guard.GetComponent<GuardAI>();
                guardScript.Distraction(position);
            }
        }
    }

    IEnumerator CoinCountDown(int time) //cooldown time for coin spawning
    {
        if(coinCount < 2)
        {
            yield return new WaitForSeconds(time);
            coinCount++;
        }
    }

    
}
