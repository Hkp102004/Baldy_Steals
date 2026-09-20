using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private NavMeshAgent agentboyG; //agentboy for Guard
    [SerializeField] private int currentIndex = 0;
    // [SerializeField] private bool reverse = false; //since we are going with random logic but I'll let it stay here for future
    [SerializeField] private bool reached = false;
    [SerializeField] private float startIdle = 1f;
    [SerializeField] private float endIdle = 5f;
    [SerializeField] private bool distracted = false;
    private Vector3 distractionPoint;
    private Player player; //this is the playerScript
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agentboyG = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if(agentboyG == null)
        {
            Debug.LogError("NavMeshAgent is misssing in guardAI Script");
        }
        if(waypoints.Count == 0)
        {
            Debug.LogError("Waypoints are missing in guardAI Script");
        }
        if(animator == null)
        {
            Debug.LogError("Animator controller is missing in the "+ gameObject.name + " GameObject");
            return;
        }
        if(player == null)
        {
            Debug.LogError("GuardAI script was not able to fetch Player script due to some reason");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( waypoints.Count >0 && waypoints[currentIndex] != null & !distracted) //for normal following of code
        {
            agentboyG.SetDestination(waypoints[currentIndex].position);

            float distance = Vector3.Distance(transform.position, waypoints[currentIndex].position);

            if(distance < 1.0f && !reached)
            {
                reached = true;
                StartCoroutine(IdleSeconds(startIdle, endIdle));
            }
        }

        if(distracted) //code for distracted part in update
        {
            float distance = Vector3.Distance(transform.position,distractionPoint);
            
            if(distance <1.0f && !reached)
            {
                reached = true;
                animator.SetBool("walk",false);
                StartCoroutine(DistractedIdle(startIdle,endIdle));
            }
        }
    }

    public void Distraction( Vector3 coinPoint) //distracted function 
    {
        float distance = Vector3.Distance(transform.position, coinPoint); //this to calculate if it is not too far for the guard's range

        if(distance < 10.0f)
        {
            distracted = true;
            agentboyG.SetDestination(coinPoint);
            animator.SetBool("walk",true);
            distractionPoint = coinPoint;
        }
    }

    IEnumerator DistractedIdle(float start, float end) //distraction idle
    {
        animator.SetBool("walk",false);
        float wait = Random.Range(start,end);
        yield return new WaitForSeconds(wait);
        distracted = false;
        reached = false;
        animator.SetBool("walk",true);
    }


    IEnumerator IdleSeconds(float start, float end) //normal idle shi
    {
        float randomTime = Random.Range(start, end);
        animator.SetBool("walk", false); //to make the guard stop walking and play the idle animation
        yield return new WaitForSeconds(randomTime);

        currentIndex = Random.Range(0,waypoints.Count); //this should make the guards move randomly
        if(waypoints.Count > 1)
        {
            animator.SetBool("walk",true); //to make the guard walk and only the opes that have more positions than one
        }
        reached = false;
    }



    // IEnumerator IdleSeconds(float start, float end)
    // {
    //     // Debug.Log("Wait starts now");
    //     float randomTime = Random.Range(start, end);
    //     animator.SetBool("walk", false); //to make the guard stop walking and play the idle animation
    //     yield return new WaitForSeconds(randomTime);

    //     // if(reverse)
    //     // {
    //     //     currentIndex--;
    //     //     if(currentIndex <0)
    //     //     {
    //     //         reverse = false;
    //     //         currentIndex++;
    //     //     }
    //     // }
    //     // else
    //     // {
    //     //     currentIndex++;
    //     //     currentIndex = Random.Range(0,waypoints.Count);  //experimantal code to make guard move randomly , so there will be no pattern recognition
    //     //     if(currentIndex >= waypoints.Count)
    //     //     {
    //     //         reverse = true;
    //     //         currentIndex--;
    //     //     }
    //     // }
    //     currentIndex = Random.Range(0,waypoints.Count); //this should make the guards move randomly
    //     if(waypoints.Count > 1)
    //     {
    //         // Debug.Log("Guard is moving to waypoint");
    //         animator.SetBool("walk",true); //to make the guard walk and only the opes that have more positions than one
    //     }
    //     // animator.SetBool("walk", true); //to make the guard walk again after the idle animation is done
    //     reached = false;
    // }
}

