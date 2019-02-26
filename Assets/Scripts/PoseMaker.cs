using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PoseMaker : MonoBehaviour {

    [SerializeField] string name;
    List<Quaternion> data = new List<Quaternion>();

    public void CreatePose(List<Quaternion> data)
    {
        if(name != null || name != "")
        {
            PoseSO asset = ScriptableObject.CreateInstance<PoseSO>();

            asset.name = name;
            asset.boneRotations = data;

            name = null;

            AssetDatabase.CreateAsset(asset, string.Format("Assets/SO/{0}.asset", asset.name));
        }
    }

    private void SavePoseData()
    {

    }

}
