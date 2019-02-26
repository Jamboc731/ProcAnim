using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AnimData
{
    public Transform bone;
    public Vector3 startPos;
    public Vector3 targetPos;
    public float force;
    public float stiffness;
    public float displacement;
    public float damping;
    public float velocity;
    public float minVel;
    public float timeTaken;
    public Vector3 vel;
}