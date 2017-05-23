using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScrollingBackground))]
public class ScrollingBackgroundEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script will parallax the background", MessageType.Info);

        base.OnInspectorGUI();
    }
}
