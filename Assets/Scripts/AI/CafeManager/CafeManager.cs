using System;
using System.Collections.Generic;
using UnityEngine;

public class CafeManager : Singleton<CafeManager>, IEventSource
{
    public List<Seat> seats = new List<Seat>();

    public GameObject customerPrefab;
    public Transform customerSpawnPoint;

    private void Start()
    {
        Vector3 spawnPosition = new Vector3(
            customerSpawnPoint.position.x,
            customerSpawnPoint.position.y,
            customerSpawnPoint.position.z
        );

        GameObject newCustomer = Instantiate(customerPrefab, spawnPosition, Quaternion.identity);
        newCustomer.SetActive(true);
    }

    private void Update()
    {
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
