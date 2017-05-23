using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerTurret))]
public class PlayerTurretEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script controls shooting laser bolts", MessageType.Info);

        base.OnInspectorGUI();
    }
}
