using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [Header("WayPoint status")]
    public WayPoint PreviosWaypoint;
    public WayPoint NextWaypoint;

    [Range(0f, 10f)]
    public float wayPointWidth=1f;

    public Vector3 GetPosition()
    {
        Vector3 minBound =transform.position + transform.right * wayPointWidth / 2f;
        Vector3 maxBound = transform.position - transform.right * wayPointWidth / 2f;
        return Vector3.Lerp(minBound,maxBound,Random.Range(0f,1f));

    }
}
