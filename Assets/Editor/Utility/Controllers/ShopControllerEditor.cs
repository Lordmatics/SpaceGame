using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShopController))]
public class ShopControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script contains all persistant shop information", MessageType.Info);

        ShopController script = (ShopController)target;
        if(GUILayout.Button("AssignDefaultValues"))
        {
            if(script != null)
            {
                script.AssignDefaults();
            }
        }
        base.OnInspectorGUI();
    }
}
