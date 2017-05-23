using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LaserBolt))]
public class LaserBoltEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script controls the laser bolt", MessageType.Info);

        base.OnInspectorGUI();
    }
}
