using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyTurret))]
public class EnemyTurretEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script contains data the enemies shooting", MessageType.Info);
        base.OnInspectorGUI();
    }
}
