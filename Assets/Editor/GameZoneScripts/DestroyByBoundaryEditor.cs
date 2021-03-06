﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DestroyByBoundary))]
public class DestroyByBoundaryEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script checks for out of bounds exceptions", MessageType.Info);

        base.OnInspectorGUI();
    }
}
