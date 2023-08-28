using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject planeObject;
    public GameObject wallPrefab;

    public float minX = -30f;
    public float maxX = 30f;
    public float minZ = -10f;
    public float maxZ = 10f;

    public float minDistance = 50f;

    public int numWalls = 10;

    public bool wallsSpawned;

    private List<Vector3> wallPositions = new List<Vector3>();


    private void Awake()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += StoreWallPositions;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += SpawnWalls;
        wallsSpawned = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        StoreWallPositions();
    //        SpawnWalls();
    //    }
    //}

    private Vector3 GenerateValidWallPosition()
    {
        const int maxAttempts = 100;
        int currentAttempt = 0;
        Vector3 spawnPosition;
        do
        {
            spawnPosition = GenerateRandomPosition();
            currentAttempt++;
            if (currentAttempt > maxAttempts)
            {
                Debug.Log("Max wall spawn attempts reached.");
                return Vector3.zero;
            }
        } while (!IsPositionValid(spawnPosition));
        return spawnPosition;
    }

    private Vector3 GenerateRandomPosition()
    {
        return planeObject.transform.position + GetRandomOffset();
    }

    private Vector3 GetRandomOffset()
    {
        float spawnX = Random.Range(minX, maxX);
        float spawnZ = Random.Range(minZ, maxZ);
        return new Vector3(spawnX, 0.9f, spawnZ);
    }

    private bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 wallPosition in wallPositions)
        {
            if (Vector3.Distance(position, wallPosition) < minDistance)
            {
                return false;
            }
        }
        return true;
    }

    private void SpawnWalls()
    {
        if (!wallsSpawned)
        {
            foreach (Vector3 position in wallPositions)
            {
                SpawnWall(position);
                wallsSpawned = true;
            }
        }
    }

    private void SpawnWall(Vector3 position)
    {
        Instantiate(wallPrefab, position, Quaternion.identity);
    }

    private void StoreWallPositions()
    {
        if (!wallsSpawned)
        {
            for (int i = 0; i < numWalls; i++)
            {
                Vector3 spawnPosition = GenerateValidWallPosition();
                wallPositions.Add(spawnPosition);
            }
        }
    }

}

