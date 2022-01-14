using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaypointController))]
public class WaypointEditor : Editor
{
    private enum WaypointEditorState { None, Edit };
    private WaypointEditorState editorState = WaypointEditorState.None;
    [SerializeField] private Vector3 waypoints;
    private void OnSceneGUI()
    {
        // Debug.Log("state " + editorState);
        if (IsEditing())
        {
            DisplayWaypoints();
        }

    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        string buttonText = IsEditing() ? "Save Waypoints" : "Edit Waypoints";



        if (GUILayout.Button(buttonText))
        {
            if (IsEditing())
            {
                editorState = WaypointEditorState.None;
            }
            else
            {
                editorState = WaypointEditorState.Edit;
            }
        }
    }


    private GameObject[] editableWaypoints;
    private void DisplayWaypoints()
    {
        WaypointController waypointController = (WaypointController)target;

        Vector3[] waypoints = waypointController.WayPoints;

        editableWaypoints = new GameObject[waypoints.Length];

        for (int i = 0; i < waypoints.Length; i++)
        {
            Vector3 item = waypoints[i];

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            cube.transform.position = item;
            editableWaypoints[i] = cube;
        }
    }

    private void SaveWayPoints()
    {
        WaypointController waypointController = (WaypointController)target;

        Vector3[] waypoints = new Vector3[editableWaypoints.Length];

        for (int i = 0; i < editableWaypoints.Length; i++)
        {
            GameObject item = editableWaypoints[i];

            waypoints[i] = item.transform.position;
        }

        waypointController.WayPoints = waypoints;
    }


    private bool IsEditing()
    {
        return editorState == WaypointEditorState.Edit;
    }

}
