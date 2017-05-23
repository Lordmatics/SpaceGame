using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerMovement))]
public class PlayerMovementEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script controls the player", MessageType.Info);

        base.OnInspectorGUI();
    }
}
