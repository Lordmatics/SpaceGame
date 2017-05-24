using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ExpController))]
public class ExpControllerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script contains the look up table for exp", MessageType.Info);

        base.OnInspectorGUI();
    }
}
