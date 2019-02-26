using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PoseMaker))]
public class CreateSOofPose : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PoseMaker script = (PoseMaker)target;

        if(GUILayout.Button("Save Pose"))
        {
            //script.CreatePose();
        }

    }

}
