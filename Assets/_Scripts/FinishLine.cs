using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    private AudioSource audioSource;
    private int finishCount = 0;

    //public AudioClip finishedClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && finishCount <= 0)
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionFinishLine();
            audioSource.Play();
            finishCount++;
        }
    }

}
