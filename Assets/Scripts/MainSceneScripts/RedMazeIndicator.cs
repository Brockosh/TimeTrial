using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMazeIndicator : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionRedZone();
        }
    }
}
