using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))][RequireComponent(typeof(Animator))]
public class MinionAI : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    public GameObject[] waypoints;
    public VelocityReporter movP;
    int currWaypoint = -1;
    float headTime = 0;

    public enum AIState
    {
        NormalWaypoint,
        MovingWaypoint
    }

    public AIState aiState;


    public void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        SetNextWaypoint();
    }

    public void Update()
    {
        anim.SetFloat("vely", agent.velocity.magnitude / agent.speed);
        switch (aiState)
        {
            case AIState.NormalWaypoint:
                if (agent.remainingDistance <= 0)
                {
                    SetNextWaypoint();
                }
                break;
            case AIState.MovingWaypoint:
                headTime = Vector3.Distance(movP.gameObject.transform.position, agent.transform.position) / agent.speed;
                Vector3 x = movP.velocity * headTime;
                agent.SetDestination(movP.gameObject.transform.position + x);
                if (agent.remainingDistance < 2f)
                {
                    aiState = AIState.NormalWaypoint;
                }
                break;     
        }
    }

    private void SetNextWaypoint()
    {
        currWaypoint++;
        if (currWaypoint >= waypoints.Length)
        {
            currWaypoint = 0;
            aiState = AIState.MovingWaypoint;
        }
        agent.SetDestination(waypoints[currWaypoint].transform.position);
    }
}
