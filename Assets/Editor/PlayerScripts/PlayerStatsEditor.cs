using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerStats))]
public class PlayerStatsEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script contains the players level info", MessageType.Info);

        //base.OnInspectorGUI();

        //PlayerStats script = (PlayerStats)target;
        //if (script != null)
        //{
        //    script.Experience = EditorGUILayout.IntField("Experience", script.Experience);
        //    EditorGUILayout.LabelField("Level", script.level.ToString());

        //    //script.levelTable = (Dictionary<int,int>)EditorGUILayout.ObjectField("LevelTable", script.levelTable, typeof(Dictionary<int,int>), true);
        //}
    }
}
