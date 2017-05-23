using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Value))]
public class ValueEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script contains the value of an object in terms of scoring", MessageType.Info);

        base.OnInspectorGUI();
    }
}
