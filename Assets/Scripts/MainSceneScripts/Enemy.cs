using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject player;
    private Vector3 playerPosition;
    private float moveSpeed = 0.004f;

    private void Start()
    {
        transform.Rotate(0, 180, 0);
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemy += DestroyEnemy;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += DestroyEnemy;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        playerPosition = player.transform.position;
        MoveEnemyTowardsPlayer();
        RotateEnemyTowardsPlayer();
    }
    private void MoveEnemyTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveSpeed);
    }

    private void RotateEnemyTowardsPlayer()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionEnemy();
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        Debug.Log("Enemy Destroyed");
    }

    private void DestroyEnemyWithDelay()
    {
        Destroy(gameObject, 2);
        Debug.Log("Enemy Destroyed");
    }

    private void OnDestroy()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemy -= DestroyEnemy;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit -= DestroyEnemy;
    }
}
