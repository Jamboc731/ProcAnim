using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedComponent : MonoBehaviour {

    public AnimData data;
    Vector3 startPos;

    public GameObject[] poses;

    //[SerializeField] Transform target;
    //[SerializeField] float force;
    //[SerializeField] float stiff;
    //[SerializeField] float damping;
    //[SerializeField] float minimumVelocity;
    [SerializeField] float time;

    private void Start()
    {
        InitData();
    }

    private void InitData()
    {
        data = new AnimData();

        data.bone = transform;
        data.targetPos = startPos + Vector3.up * 5;
        //data.force = force;
        //data.stiffness = stiff;
        //data.damping = damping;
        //data.minVel = minimumVelocity;
        data.timeTaken = time;
        data.startPos = startPos;
        //Debug.Log(data.targetPos + " " + transform.position);
        data.vel = (transform.position - data.targetPos).normalized * Vector3.Distance(data.targetPos, transform.position);
    }

    public AnimData GetData()
    {
        return data;
    }
}