using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArrowNPCMovement : MonoBehaviour
{
    public GameObject targetGO;
    private NavMeshAgent navMeshAgent;
    private float runAwayMultiplier = 2;
    private float runAwayDistance;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        runAwayDistance = navMeshAgent.stoppingDistance * runAwayMultiplier;
    }

    private void Update()
    {
        Vector3 enemyPosition = targetGO.transform.position;
        float distanceFromEnemy = Vector3.Distance(enemyPosition, transform.position);
        if(distanceFromEnemy < runAwayDistance)
        {
            FleeFromTarget(enemyPosition);
        }
    }

    private void FleeFromTarget(Vector3 enemyPosition)
    {
        Vector3 fleeToPosition = Vector3.Normalize(transform.position - enemyPosition) * runAwayDistance;
        HeadForDestination(fleeToPosition);
    }

    private void HeadForDestination(Vector3 destination)
    {
        //Vector3 destination = targetGO.transform.position;
        navMeshAgent.SetDestination(destination);
    }
}
