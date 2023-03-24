using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool destroyable;

    //C
    private void OnTriggerEnter(Collider other)
    {
        if (destroyable)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                Destroy(gameObject);
                Debug.Log("Collision has occured (Door)");
            }
        }
    }


    //Create a public variable 'Deestroyable' bool (automatically set to false) 
    //If destroyable == true (can run code) 
    //Another script doorController with a list of doors
    // On start pick a random door and set destroyable == true



}
