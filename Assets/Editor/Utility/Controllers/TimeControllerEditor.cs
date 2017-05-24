using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TimeController))]
public class TimeControllerEditor : Editor
{

    public override void OnInspectorGUI()
    {

        EditorGUILayout.HelpBox("This script tracks game time", MessageType.Info);

        base.OnInspectorGUI();
    }
}
