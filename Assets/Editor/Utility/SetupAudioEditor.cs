using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SetupAudio))]
public class SetupAudioEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script picks the correct clip to play and adjusts volume", MessageType.Info);

        base.OnInspectorGUI();
    }
}
