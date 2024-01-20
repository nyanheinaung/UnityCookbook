using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetTargetPosition(Vector3 swarmCenterAverage, Vector3 swarmMovementAverage)
    {
        Vector3 destination = swarmCenterAverage + swarmMovementAverage;
        navMeshAgent.SetDestination(destination);
    }

}
