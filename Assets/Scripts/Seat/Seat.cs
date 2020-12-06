using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Seat class is 
/// </summary>
public class Seat : MonoBehaviour, IDestination
{
    [Header("Settings")]
    public int maxRange = 10;
    public BehaviourTreeType behaviourTreeType;
    public float cooldownTime = 0;
    
    internal bool seatTaken = false;
    internal bool shouldUpdateCooldown = true;
    float cooldownTimer = 0;

    public SeatRuntimeSet RuntimeSet;

    private void OnEnable()
    {
        RuntimeSet.Add(this);
    }

    private void OnDisable()
    {
        RuntimeSet.Remove(this);
    }

    private void Awake()
    {
        SeatManager.RegisterSeat(this);
    }

    private void Update()
    {
        if (shouldUpdateCooldown && cooldownTimer > 0) 
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public bool IsOnCooldown() { return cooldownTimer > 0; }

    public bool IsAvailable() { return seatTaken; }

    public void OnSeatReached()
    {
        seatTaken = true;
        shouldUpdateCooldown = false;
        cooldownTimer = 0;
    }

    public void OnExit()
    {
        seatTaken = false;
        shouldUpdateCooldown = true;
        cooldownTimer = cooldownTime;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void OnDestinationReached()
    {
        UnityEngine.Debug.Log(seatTaken);
        OnSeatReached();
    }
}
