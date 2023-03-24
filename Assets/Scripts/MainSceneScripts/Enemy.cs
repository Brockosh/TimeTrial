using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject player;

    private Vector3 playerPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemy += DestroyEnemy;
    }

    private void Update()
    {
        playerPosition = player.transform.position;
        MoveEnemyTowardsPlayer();
    }
    private void MoveEnemyTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, 0.002f);
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
    }

    private void OnDestroy()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemy -= DestroyEnemy;
    }
}
