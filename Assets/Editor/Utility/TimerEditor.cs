using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TimerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("An instance of this script suggests managing time", MessageType.Info);

        base.OnInspectorGUI();
    }
}
