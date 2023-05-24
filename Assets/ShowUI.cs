using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    [SerializeField] GameObject UI;

    private void Start()
    {
        GameManager.instance.mathEvents.OnPlayerFinishedMathsScene += DisableUI;
    }
    private void OnTriggerEnter(Collider other)
    {
        UI.SetActive(true);
        //UI.alpha = 1.0f;
        //UI.interactable = true;
        //UI.blocksRaycasts = true;
        GameManager.instance.CollisionEvent.CallPlayerCollisionMathsLevel();

    }

    private void DisableUI()
    {
        UI.SetActive(false);
    }
}
