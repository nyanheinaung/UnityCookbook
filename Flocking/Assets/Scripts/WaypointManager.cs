using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaypointManager : MonoBehaviour
{
    public GameObject[] waypoints;

    public GameObject NextWayPoint(GameObject current)
    {
        if(waypoints.Length < 0)
        {
            Debug.LogError("WaypointManager :: ERROR - no waypoints have been added to array!");
        }

        int currentIndex = Array.IndexOf(waypoints, current);

        int nextIndex = ((currentIndex + 1) % waypoints.Length);
        

        return waypoints[nextIndex];
    }
}
