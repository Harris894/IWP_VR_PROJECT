using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    const string gizmoNameSeatActive = "TerrainSeatIconActive.png";
    const string gizmoNameSeatInactive = "TerrainSeatIconAvailable.png";
    const string gizmoNameCooldown = "TerrainSeatIconCooldown.png";

    [Header("Settings")]
    public int maxRange = 10;
    public BehaviourTreeType behaviourTreeType;
    public float waitAtPathSeatTime = 0;
    public float cooldownTime = 0;

    [Header("Animation Settings")]
    public string onSeatReachedTriggerName;
    public string onPathEndTriggerName;
    
    List<Transform> seatsList;
    internal bool seatTaken = false;
    internal bool endSeatReached = false;
    int nextPathSeatIndex = 0;
    float cooldownTimer = 0;

    private void Awake()
    {
        seatsList = new List<Transform>(GetComponentsInChildren<Transform>());
        SeatManager.RegisterSeat(this);
    }

    private void Update()
    {
        if (cooldownTimer > 0) 
        {
            cooldownTimer -= Time.deltaTime;
        }
    }


    internal bool IsOnLastSeat()
    {
        return nextPathSeatIndex == seatsList.Count - 1;
    }

    internal bool IsOnFirstSeat() { return nextPathSeatIndex == 1; }

    public bool IsOnCooldown() { return cooldownTimer > 0; }

    public void OnSeatReached()
    {
        if (seatsList.Count != 0)
        {
            ++nextPathSeatIndex;

            if (nextPathSeatIndex >= seatsList.Count)
            {
                endSeatReached = true;
                nextPathSeatIndex = seatsList.Count - 1;
            }
        }
    }

    public Vector3 GetNextSeat()
    {
        return seatsList.Count == 0 ? Vector3.zero : seatsList[nextPathSeatIndex].position; 
    }

    public void Reset()
    {
        seatTaken = false;
        nextPathSeatIndex = 0;
        cooldownTimer = 0;
    }

    public void OnExit()
    {
        endSeatReached = false;
        cooldownTimer = cooldownTime;
        seatTaken = false;
    }

    void OnDrawGizmos()
    {
        Transform[] terrainSeats = GetComponentsInChildren<Transform>();
        string gizmoName = cooldownTimer > 0 ? gizmoNameCooldown : seatTaken ? gizmoNameSeatActive : gizmoNameSeatInactive;
        Gizmos.DrawIcon(transform.position + Vector3.up * 0.5f, gizmoName, true);

        Gizmos.color = Color.green;

        for (int i = 0; i < terrainSeats.Length; ++i)
        {
            if (i == 0)
            {
                Gizmos.DrawLine(transform.position, terrainSeats[0].position);
            }
            else
            {
                Gizmos.DrawLine(terrainSeats[i - 1].position, terrainSeats[i].position);
            }

            Gizmos.DrawCube(terrainSeats[i].position, Vector3.one * 0.2f);
        }
    }
}
