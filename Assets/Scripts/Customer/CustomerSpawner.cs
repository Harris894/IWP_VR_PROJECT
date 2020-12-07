using UnityEngine;
using FuzeStudios.Variables;

public class CustomerSpawner : MonoBehaviour
{
    public CustomerRuntimeSet Set;
    public FloatVariable SpawnCooldown;

    public GameObject customerPrefab;
    public Transform customerSpawnPoint;

    private float cooldownTimer = 0;

    private void Start()
    {
    }

    private void Update()
    {
        if (cooldownTimer > 0) 
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector3 spawnPosition = new Vector3(
            customerSpawnPoint.position.x,
            customerSpawnPoint.position.y,
            customerSpawnPoint.position.z
        );

        GameObject newCustomer = Instantiate(customerPrefab, spawnPosition, Quaternion.identity);
        newCustomer.SetActive(true);
        
        cooldownTimer = SpawnCooldown.Value;
    }

    public void Reset()
    {
        cooldownTimer = 0;
    }
}
