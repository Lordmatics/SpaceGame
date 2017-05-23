using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Asteroid))]
public class AsteroidEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script contains data for the asteroid", MessageType.Info);
        base.OnInspectorGUI();
    }
}
