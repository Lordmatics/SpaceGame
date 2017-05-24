using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Durability))]
public class DurabilityEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script contains the hit points of whatever its attached to!", MessageType.Info);

        base.OnInspectorGUI();
    }
}
