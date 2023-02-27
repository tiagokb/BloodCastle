using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITargetable
{
    ObjectType Type { get; }
    bool IsKillable { get; }
}

public class Targetable : MonoBehaviour, ITargetable
{

    public ObjectType Type;
    ObjectType ITargetable.Type => Type;
    
    public bool IsKillable => Type == ObjectType.Enemy || Type == ObjectType.Object;

    public Transform Transform => transform;

    

    public void OnTargeted()
    {
        // TODO: Implement what happens when this target is targeted
    }

    public void OnUntargeted()
    {
        // TODO: Implement what happens when this target is untargeted
    }
}