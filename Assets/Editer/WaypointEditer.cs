using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

[InitializeOnLoad()]
public class WaypointEditer
{
    [DrawGizmo(GizmoType.NonSelected|GizmoType.Selected|GizmoType.Pickable)]
    public static void OnDrowSceneGizmos(WayPoint wayPoint,GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.blue;
        }
        else
        {
            Gizmos.color= Color.blue*0.5f;
        }
        Gizmos.DrawSphere(wayPoint.transform.position, 0.1f);
        Gizmos.color=Color.white;
        Gizmos.DrawLine(wayPoint.transform.position + (wayPoint.transform.right * wayPoint.wayPointWidth / 2f), wayPoint.transform.position - (wayPoint.transform.right * wayPoint.wayPointWidth / 2f));
        if(wayPoint.PreviosWaypoint != null)
        {
            Gizmos.color = Color.red;
            Vector3 offset=wayPoint.transform.right*wayPoint.wayPointWidth/2f;
            Vector3 offsetTo = wayPoint.PreviosWaypoint.transform.right * wayPoint.PreviosWaypoint.wayPointWidth / 2f;
            Gizmos.DrawLine(wayPoint.transform.position+offset,wayPoint.PreviosWaypoint.transform.position+offsetTo);
        }
        if(wayPoint.NextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Vector3 offset = wayPoint.transform.right * -wayPoint.wayPointWidth / 2f;
            Vector3 offsetTo = wayPoint.PreviosWaypoint.transform.right * -wayPoint.PreviosWaypoint.wayPointWidth / 2f;
            Gizmos.DrawLine(wayPoint.transform.position + offset, wayPoint.PreviosWaypoint.transform.position + offsetTo);
        }
    }
}
