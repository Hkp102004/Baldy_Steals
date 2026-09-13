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
    [SerializeField] private bool reached = false;
    [SerializeField] private float startIdle = 1f;
    [SerializeField] private float endIdle = 5f;
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

            if(distance < 1.0f && !reached)
            {

                reached = true;
                StartCoroutine(IdleSeconds(startIdle, endIdle));
            }
        }
    }


    IEnumerator IdleSeconds(float start, float end)
    {
        Debug.Log("Wait starts now");
        float randomTime = Random.Range(start, end);
        yield return new WaitForSeconds(randomTime);

        if(reverse)
        {
            currentIndex--;
            if(currentIndex <0)
            {
                reverse = false;
                currentIndex++;
            }
        }
        else
        {
            currentIndex++;
            // currentIndex = Random.Range(0,3);  //experimantal code to make guard move randomly , so there will be no pattern recognition
            if(currentIndex >= waypoints.Count)
            {
                reverse = true;
                currentIndex--;
            }
        }
        reached = false;
    }
}
