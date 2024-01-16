using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArrowNPCMovement : MonoBehaviour
{
    public GameObject targetGO;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        HeadForDestination();
    }

    private void Update()
    {
        HeadForDestination();    
    }

    private void HeadForDestination()
    {
        Vector3 destination = targetGO.transform.position;
        navMeshAgent.SetDestination(destination);
    }
}
