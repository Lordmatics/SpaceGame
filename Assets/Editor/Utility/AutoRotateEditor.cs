using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AutoRotate))]
public class AutoRotateEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AutoRotate script = (AutoRotate)target;
        EditorGUILayout.HelpBox("This script will rotate its gameobject when selected and in game", MessageType.Info);
        //If a vlue was changed this is true

        base.OnInspectorGUI();

        if(GUILayout.Button("Adjust Rigidbody"))
        {
            script.ApplyRotation();
        }
    }

}
