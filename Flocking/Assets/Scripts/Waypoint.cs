using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint[] waypoints;

    public Waypoint GetNextWayPoint()
    {
        return waypoints[Random.Range(0,waypoints.Length)];
    }
}
