using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DestroyByContact))]
public class DestroyByContactEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script checks for contact destruction", MessageType.Info);

        base.OnInspectorGUI();
    }
}
