using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScoreController))]
public class ScoreControllerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script handles scoring in the game", MessageType.Info);

        base.OnInspectorGUI();
    }
}
