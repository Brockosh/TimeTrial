using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMazeIndicator : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionYellowZone();
        }
    }
}
