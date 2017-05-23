using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyMovement))]
public class EnemyMovementEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script contains data evasive movement", MessageType.Info);
        base.OnInspectorGUI();
    }
}
