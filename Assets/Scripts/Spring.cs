using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

    AnimData data;
    Vector3 startPos;
    [SerializeField] Transform target;
    [SerializeField] float force;
    [SerializeField] float stiff;
    [SerializeField] float damping;
    [SerializeField] float minimumVelocity;
    [SerializeField] float time;

    Vector3 vel;

    JamieSmoothMove move = new JamieSmoothMove();

    void Start () {

        InitData();

        vel = move.GetVelocity(data) * Vector3.Distance(target.position, transform.position);

	}
	
	void Update () {

        if(Vector3.Distance(target.position, transform.position) >= 0.1f)
            move.linearInterpolate(data);
        


	}

    private void InitData()
    {
        data = new AnimData();

        data.bone = transform;
        data.targetPos = startPos * 2;
        data.force = force;
        data.stiffness = stiff;
        data.damping = damping;
        data.minVel = minimumVelocity;
        data.timeTaken = time;
        data.startPos = startPos;
    }

}
