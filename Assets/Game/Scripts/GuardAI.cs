using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private Transform destination;
    [SerializeField] private NavMeshAgent agentboyG; //agentboy for Guard
    // Start is called before the first frame update
    void Start()
    {
        agentboyG = GetComponent<NavMeshAgent>();

        if(waypoints.Count > 0) //check if first char exists
        {
            if(waypoints[0] != null) //check if the first element is not null
            {
                destination = waypoints[0];
                agentboyG.SetDestination(destination.position);
            }
        }

        if(agentboyG == null)
        {
            Debug.LogError("NavMeshAgent is missing in Guard boy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(destination != null)
        {
            float distance = Vector3.Distance(transform.position, destination.position);

            if(distance < 1.0f)
            {
                if(waypoints[1] != null && destination != waypoints[1])
                {
                    destination = waypoints[1];
                    agentboyG.SetDestination(destination.position);
                }
                else if(waypoints[2] != null)
                {
                    destination = waypoints[2];
                    agentboyG.SetDestination(destination.position);
                }
            }
        }
    }
}
