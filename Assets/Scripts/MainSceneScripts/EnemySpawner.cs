//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemySpawner : MonoBehaviour
//{
//    [SerializeField] private GameObject enemy;

//    private float minDistanceX = -10;
//    private float MaxDistanceX = 10;
//    private float minDistanceZ = -5;
//    private float MaxDistanceZ = 5;

//    private int amountOfEnemies = 3;



//    private List<Vector3> positionOfSpawnedEnemies = new List<Vector3>();
//    private List<Vector3> positionsForEnemiesToSpawnIn = new List<Vector3>();

//    private void Start()
//    {
//        CreatePositionsForEnemiesToSpawnIn();
//        SpawnEnemies();
//    }

//    private void SpawnEnemy(Vector3 enemyPosition)
//    {
//        Instantiate(enemy, enemyPosition, Quaternion.identity);
//    }

//    private void SpawnEnemies()
//    {
//        for (int i = 0; i < amountOfEnemies; i++)
//        {
//            SpawnEnemy(positionsForEnemiesToSpawnIn[i]);
//        }
//    }


//    private void CreatePositionsForEnemiesToSpawnIn()
//    {
//        for (int i = 0; i < amountOfEnemies; i++)
//        {
//            Vector3 position = transform.position;
//            position.x += Random.Range(minDistanceX, MaxDistanceX);
//            position.z += Random.Range(minDistanceZ, MaxDistanceZ);
//            positionsForEnemiesToSpawnIn.Add(position);
//        }
//    }



//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float minDistanceX = -10;
    [SerializeField] private float maxDistanceX = 10;
    [SerializeField] private float minDistanceZ = -5;
    [SerializeField] private float maxDistanceZ = 5;
    [SerializeField] private float minDistanceBetweenEnemies = 2;

    [SerializeField] private int amountOfEnemies = 3;

    private List<Vector3> positionsForEnemiesToSpawnIn = new List<Vector3>();

    private void Start()
    {
        GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionEnemySpawningPlane += CompleteSpawningProcess;

        //CreatePositionsForEnemiesToSpawnIn();
        //SpawnEnemies();
    }

    private void CreatePositionsForEnemiesToSpawnIn()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            Vector3 position = GetValidPosition();
            positionsForEnemiesToSpawnIn.Add(position);
        }
    }

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

    private Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(minDistanceX, maxDistanceX);
        float z = Random.Range(minDistanceZ, maxDistanceZ);
        Vector3 position = transform.position + new Vector3(x, 0, z);
        return position;
    }

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

    //Remove positions on collision or after enemies are spawned.
    private void SpawnEnemies()
    {
        foreach (Vector3 position in positionsForEnemiesToSpawnIn)
        {
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }
    }

    private void CompleteSpawningProcess()
    {
        CreatePositionsForEnemiesToSpawnIn();
        SpawnEnemies();
        positionsForEnemiesToSpawnIn.Clear();
    }
}

