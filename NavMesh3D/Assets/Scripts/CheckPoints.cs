using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private Vector3 respawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = transform.position;
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Checkpoint"))
        {
            respawnPosition = transform.position;
        }

        if (hit.CompareTag("Death"))
        {
            transform.position = respawnPosition;
        }
    }
}
