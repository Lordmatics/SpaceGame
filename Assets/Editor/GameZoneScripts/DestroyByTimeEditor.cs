using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DestroyByTime))]
public class DestroyByTimeEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script kills whatever its attached to after a time as passed", MessageType.Info);

        base.OnInspectorGUI();
    }
}
