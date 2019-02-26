using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class AnimationSystem : ComponentSystem
{

    List<Quaternion> data = new List<Quaternion>();

    private struct filter
    {
        public Transform Transform;
        public AnimatedComponent AnimatedComponent;
    }

    private struct p1Filter
    {
        public Transform Transform;
        public Pose1Component Pose1Component;
    }

    private struct p2Filter
    {
        public Transform Transform;
        public Pose2Component Pose2Component;
    }

    private bool p1Bool = false;

    private bool started;

    JamieSmoothMove move = new JamieSmoothMove();

    Vector3 start;
    Vector3 end;
    int currentIteration = 0;
    float fraction = 0;

    protected override void OnStartRunning()
    {
        GetBoneRotationData();
    }

    protected override void OnUpdate()
    {
        currentIteration = 0;
        foreach(var entity in GetEntities<filter>())
        {
            //move.linearInterpolate(entity.AnimatedComponent.GetData());

            entity.Transform.eulerAngles = Vector3.Slerp(entity.AnimatedComponent.GetData().startPos, data[currentIteration].eulerAngles, fraction);
            currentIteration++;



        }
        fraction += Time.deltaTime / 2;

        if(fraction >= 1)
        {
            fraction = 0;
            p1Bool = !p1Bool;
            GetBoneRotationData();
            foreach(var e in GetEntities<filter>())
            {
                e.AnimatedComponent.data.startPos = e.Transform.eulerAngles;
            }
        }

    }

    private void GetBoneRotationData()
    {
        data = new List<Quaternion>();
        if (p1Bool)
        {
            foreach(var entity in GetEntities<p1Filter>())
            {
                data.Add(entity.Transform.rotation);
            }
        }
        else
        {
            foreach(var entity in GetEntities<p2Filter>())
            {
                data.Add(entity.Transform.rotation);
            }
        }
    }

}
