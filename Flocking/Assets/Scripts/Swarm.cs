﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarm : MonoBehaviour
{
    public int droneCount = 20;
    public GameObject dronePrefab;

    private List<Drone> drones = new List<Drone>();

    private void Awake()
    {
        for (int i = 0; i < droneCount; i++)
        {
            AddDrone();
        }
    }

    private void FixedUpdate()
    {
        Vector3 swarmCenter = SwarmCenterAverage();
        Vector3 swarmMovement = SwarmMovementAverage();

        foreach (Drone drone in drones)
        {
            drone.SetTargetPosition(swarmCenter, swarmMovement);
        }
    }

    void AddDrone()
    {
        GameObject newDroneGO = (GameObject)Instantiate(dronePrefab);
        Drone newDrone = newDroneGO.GetComponent<Drone>();
        drones.Add(newDrone);
    }

    private Vector3 SwarmCenterAverage()
    {
        // cohesion(swarm center point)
        Vector3 locationTotal = Vector3.zero;

        foreach(Drone drone in drones)
        {
            locationTotal += drone.transform.position;
        }

        return (locationTotal/drones.Count);
    }

    private Vector3 SwarmMovementAverage()
    {
        //alignment(swarm direction average)
        Vector3 velocityTotal = Vector3.zero;

        foreach(Drone drone in drones)
        {
            velocityTotal += drone.GetComponent<Rigidbody>().velocity;
        }
        return (velocityTotal/drones.Count);
    }
}
