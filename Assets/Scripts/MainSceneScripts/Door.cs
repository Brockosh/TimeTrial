using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool destroyable;
 
    private void OnTriggerEnter(Collider other)
    {
        if (destroyable)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                transform.Rotate(0f, 90f, 0f);
                
                //Destroy(gameObject);
                Debug.Log("Collision has occured (Door)");
            }
        }
    }

}
