using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TowerBase), true)]
public class TowerBaseEditor : Editor
{
    void OnSceneGUI()
    {
        TowerBase context = ((TowerBase) target);

        Handles.color = Color.cyan;
        Handles.RadiusHandle(context.transform.rotation, context.transform.position, context.Range);
    }
}
