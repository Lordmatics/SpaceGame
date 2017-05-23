using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameController))]
public class GameControllerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script manages the waves", MessageType.Info);

        base.OnInspectorGUI();
    }
}
