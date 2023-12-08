using UnityEditor;
using UnityEngine;

public class WayPointManagerWindow : EditorWindow
{
    [MenuItem("Waypoints/Waypoints Editor Tools")]
    public static void ShowWindow()
    {
        GetWindow<WayPointManagerWindow>("Waypoints Editor Tools");
    }
    public Transform waypointOrigin;
    private void OnGUI()
    {
        SerializedObject obj= new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("waypointOrigin"));
        if (waypointOrigin == null)
        {
            EditorGUILayout.HelpBox("Please assign a waypoint origin transform", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical();
            CreateButtens();
            EditorGUILayout.EndVertical();
        }
         
        obj.ApplyModifiedProperties(); 
    }
    void CreateButtens()
    {
        if (GUILayout.Button("create Waypoint"))
        {
            CreateWaypopint();
        }
    }
    void CreateWaypopint()
    {
        GameObject waypointObject = new GameObject("waypoint " + waypointOrigin.childCount, typeof(WayPoint));
        waypointObject.transform.SetParent(waypointOrigin, false);
        WayPoint wayPoint =waypointObject.GetComponent<WayPoint>();

        if (waypointOrigin.childCount > 1)
        {
            wayPoint.PreviosWaypoint = waypointOrigin.GetChild(waypointOrigin.childCount - 2).GetComponent<WayPoint>();
            wayPoint.PreviosWaypoint.NextWaypoint = wayPoint;
            wayPoint.transform.position = wayPoint.PreviosWaypoint.transform.position;
            wayPoint.transform.forward= wayPoint.PreviosWaypoint.transform.forward;
        }
        Selection.activeObject = wayPoint.gameObject;
    }
}
