using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    [SerializeField] private Vector3[] waypoints;

    public Vector3[] WayPoints
    {
        get
        {
            return waypoints;
        }
        set
        {
            waypoints = value;
        }
    }



}
