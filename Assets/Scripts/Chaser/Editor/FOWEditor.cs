using UnityEngine;
using UnityEditor;
using Chaser;

[CustomEditor(typeof(FOW))]
public class FieldOfViewEditor : Editor
{
    void OnSceneGUI()
    {
        FOW fow = (FOW)target;
        Handles.color = Color.magenta;

        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.up, 360, fow.viewRadius);

        Vector2 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector2 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);

        Vector2 fotPos = fow.transform.position;

        Handles.DrawLine(fotPos, fotPos + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fotPos, fotPos + viewAngleB * fow.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fow.visibleTargets)
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
    }

}