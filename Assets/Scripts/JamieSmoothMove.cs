using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamieSmoothMove
{

    /*
        spring eqn: f = -kx - bv
        f: force
        k: stiffness
        x: displacement
        b: damping
        v: velocity

        rearranged to get velocity: v = (f + kx)/-b
    */

    Vector3 vel;

    public void SmoothMove(AnimData _data)
    {

        AnimData d = _data;


        vel = GetVelocity(d);
        Debug.Log(vel.magnitude);
        if(vel.magnitude >= d.minVel)
            d.bone.Translate(vel * Time.deltaTime);


    }

    public void linearInterpolate(AnimData d)
    {
        //Debug.Log(string.Format("{0}, {1}", d.vel, d.timeTaken));
        d.bone.Translate(d.vel / d.timeTaken * Time.deltaTime);

    }

    public Vector3 GetVelocity(AnimData _data)
    {
        AnimData d = _data;
        Vector3 v = Vector3.zero;
        v = -(d.bone.position - d.targetPos);
        v = v.normalized;

        #region failed attempt
        //float vMagnitude = 0;

        //d.displacement = Vector3.Distance(d.bone.position, d.targetPos);

        //vMagnitude = (d.force + (d.stiffness * d.displacement)) / -d.damping;

        //v = v.normalized;

        //v *= vMagnitude;
        #endregion




        return v;
    }

}
