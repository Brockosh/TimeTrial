using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMazeIndicator : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionGreenZone();
        }
    }
}
