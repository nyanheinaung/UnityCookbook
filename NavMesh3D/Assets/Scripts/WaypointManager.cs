using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public GameObject wayPoint0;
    public GameObject wayPoint3;

    public GameObject NextWayPoint(GameObject current)
    {
        if (current == wayPoint0)
        {
            return wayPoint3;
        }
        else
        {
            return wayPoint0;
        }

    }
}
