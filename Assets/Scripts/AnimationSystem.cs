using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class AnimationSystem : ComponentSystem
{

    private struct filter
    {
        public Transform Transform;
        public AnimatedComponent AnimatedComponent;
    }
    JamieSmoothMove move = new JamieSmoothMove();

    protected override void OnUpdate()
    {
        
        foreach(var entity in GetEntities<filter>())
        { 
            move.linearInterpolate(entity.AnimatedComponent.GetData());
        }

    }

}
