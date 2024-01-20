using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArrowNPCMovement2 : MonoBehaviour
{
    private GameObject targetGO = null;
    private WaypointManager waypointManager;
    private NavMeshAgent navMeshAgent;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        waypointManager = GetComponent<WaypointManager>();
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
        targetGO = waypointManager.NextWayPoint(targetGO);
        navMeshAgent.SetDestination(targetGO.transform.position);
    }
}
