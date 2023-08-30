using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Serialized fields for prefab and spawn settings
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minDistanceX = -10;
    [SerializeField] private float maxDistanceX = 10;
    [SerializeField] private float minDistanceZ = -5;
    [SerializeField] private float maxDistanceZ = 5;
    [SerializeField] private float minDistanceBetweenEnemies = 2;
    [SerializeField] private int amountOfEnemies = 3;

    // List to store positions for enemies to spawn
    private List<Vector3> positionsForEnemiesToSpawnIn = new List<Vector3>();

    // Subscribe to CollisionEvent in GameManager to trigger enemy spawning
    private void Start()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += CompleteSpawningProcess;
    }

    // Create valid positions for each enemy to spawn
    private void CreatePositionsForEnemiesToSpawnIn()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            Vector3 position = GetValidPosition();
            positionsForEnemiesToSpawnIn.Add(position);
        }
    }

    // Generate a valid position for an enemy to spawn
    private Vector3 GetValidPosition()
    {
        Vector3 position = transform.position;
        bool positionIsValid = false;
        while (!positionIsValid)
        {
            position = GenerateRandomPosition();
            positionIsValid = CheckIfPositionIsValid(position);
        }
        return position;
    }

    // Generate a random position within the defined bounds
    private Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(minDistanceX, maxDistanceX);
        float z = Random.Range(minDistanceZ, maxDistanceZ);
        Vector3 position = transform.position + new Vector3(x, 0, z);
        return position;
    }

    // Check if a generated position is valid based on distance to other positions
    private bool CheckIfPositionIsValid(Vector3 position)
    {
        foreach (Vector3 otherPosition in positionsForEnemiesToSpawnIn)
        {
            if (Vector3.Distance(position, otherPosition) < minDistanceBetweenEnemies)
            {
                return false;
            }
        }
        return true;
    }

    // Instantiate enemies at generated positions
    private void SpawnEnemies()
    {
        foreach (Vector3 position in positionsForEnemiesToSpawnIn)
        {
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }
    }

    // Complete the spawning process by generating positions and spawning enemies
    private void CompleteSpawningProcess()
    {
        CreatePositionsForEnemiesToSpawnIn();
        SpawnEnemies();
        positionsForEnemiesToSpawnIn.Clear();
    }
}


//using System.Collections.Generic;
//using UnityEngine;

//public class EnemySpawner : MonoBehaviour
//{
//    [SerializeField] private GameObject enemyPrefab;

//    [SerializeField] private float minDistanceX = -10;
//    [SerializeField] private float maxDistanceX = 10;
//    [SerializeField] private float minDistanceZ = -5;
//    [SerializeField] private float maxDistanceZ = 5;
//    [SerializeField] private float minDistanceBetweenEnemies = 2;

//    [SerializeField] private int amountOfEnemies = 3;

//    private List<Vector3> positionsForEnemiesToSpawnIn = new List<Vector3>();

//    private void Start()
//    {
//        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += CompleteSpawningProcess;
//    }

//    private void CreatePositionsForEnemiesToSpawnIn()
//    {
//        for (int i = 0; i < amountOfEnemies; i++)
//        {
//            Vector3 position = GetValidPosition();
//            positionsForEnemiesToSpawnIn.Add(position);
//        }
//    }

//    private Vector3 GetValidPosition()
//    {
//        Vector3 position = transform.position;
//        bool positionIsValid = false;
//        while (!positionIsValid)
//        {
//            position = GenerateRandomPosition();
//            positionIsValid = CheckIfPositionIsValid(position);
//        }
//        return position;
//    }

//    private Vector3 GenerateRandomPosition()
//    {
//        float x = Random.Range(minDistanceX, maxDistanceX);
//        float z = Random.Range(minDistanceZ, maxDistanceZ);
//        Vector3 position = transform.position + new Vector3(x, 0, z);
//        return position;
//    }

//    private bool CheckIfPositionIsValid(Vector3 position)
//    {
//        foreach (Vector3 otherPosition in positionsForEnemiesToSpawnIn)
//        {
//            if (Vector3.Distance(position, otherPosition) < minDistanceBetweenEnemies)
//            {
//                return false;
//            }
//        }
//        return true;
//    }

//    private void SpawnEnemies()
//    {
//        foreach (Vector3 position in positionsForEnemiesToSpawnIn)
//        {
//            Instantiate(enemyPrefab, position, Quaternion.identity);
//        }
//    }

//    private void CompleteSpawningProcess()
//    {
//        CreatePositionsForEnemiesToSpawnIn();
//        SpawnEnemies();
//        positionsForEnemiesToSpawnIn.Clear();
//    }
//}

