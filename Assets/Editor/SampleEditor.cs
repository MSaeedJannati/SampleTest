using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(LerpMoveTest))]
public class SampleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        LerpMoveTest instance = (LerpMoveTest)target;
        GUILayout.Label("Custom Buttons:");
        if (GUILayout.Button("Move"))
        {
            instance.Move();
        }
    }
}
