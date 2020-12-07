using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Entrance class is 
/// </summary>
public class Entrance : Singleton<Entrance>, IDestination
{
    [Header("Settings")]
    public BehaviourTreeType behaviourTreeType;

    private void Start()
    {   
    }

    private void Update()
    {   
    }

    public void OnEntranceReached()
    {
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void OnDestinationReached()
    {
        OnEntranceReached();
    }
}
