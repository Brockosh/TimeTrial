using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeEntrance : MonoBehaviour
{

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        GameManager.instance.CollisionEvent.CallPlayerCollisionMazeEntrance();
    //        Debug.Log("Maze Entrance event has been called");
    //    }
    //}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionMazeEntrance();
            Debug.Log("Maze Entrance event has been called");
        }
    }

}
