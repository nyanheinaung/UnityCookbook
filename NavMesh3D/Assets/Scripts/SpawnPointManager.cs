using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    private GameObject[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
    }

    public GameObject RandomSpawnPoint()
    {
        int r = Random.Range(0, spawnPoints.Length);
        return spawnPoints[r];
    }
}
