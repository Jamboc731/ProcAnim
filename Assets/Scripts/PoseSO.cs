using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pose", menuName = "New Pose")]
public class PoseSO : ScriptableObject {

    [HideInInspector]
    public string name;
    [HideInInspector]
    public List<Quaternion> boneRotations = new List<Quaternion>();

}
