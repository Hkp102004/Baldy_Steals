using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private NavMeshAgent agentboyG; //agentboy for Guard
    [SerializeField] private int currentIndex = 0;
    [SerializeField] private bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        agentboyG = GetComponent<NavMeshAgent>();

        if(agentboyG == null)
        {
            Debug.LogError("NavMeshAgent is misssing in guardAI Script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( waypoints.Count >0 && waypoints[currentIndex] != null)
        {
            agentboyG.SetDestination(waypoints[currentIndex].position);

            float distance = Vector3.Distance(transform.position, waypoints[currentIndex].position);

            if(distance < 1.0f)
            {
                if(reverse == false)
                {
                    currentIndex++;
                }
                else if(reverse == true)
                {
                    currentIndex--;
                }

                if(currentIndex >= waypoints.Count)
                {
                    reverse = true;
                    currentIndex--;
                }
                if(currentIndex < 0)
                {
                    reverse = false;
                    currentIndex++;
                }
            }
        }
    }
}
