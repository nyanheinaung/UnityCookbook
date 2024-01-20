using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArrowNPCMovement3 : MonoBehaviour
{
    public Waypoint waypoint;
    private bool firstWayPoint = true;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        HeadForNextWayPoint();
    }

    // Update is called once per frame



    void Update()
    {
        float closeToDestination = navMeshAgent.stoppingDistance * 2;
        if(navMeshAgent.remainingDistance < closeToDestination)
        {
            HeadForNextWayPoint();
        }
    }

    private void HeadForNextWayPoint()
    {
        if (firstWayPoint)
        {
            firstWayPoint = false;
        }
        else
        {
            waypoint = waypoint.GetNextWayPoint();
        }

        Vector3 target = waypoint.transform.position;
        navMeshAgent.SetDestination(target);

    }
}
