using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsSceneText : MonoBehaviour
{
    public void ActivateCorrectText()
    {
        gameObject.SetActive(true);
        Debug.Log("Text should be activated");
    }

    public void DeactivateCorrectText()
    {
        gameObject.SetActive(false);
    }

}
