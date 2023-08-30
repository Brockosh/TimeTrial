using UnityEngine;
using DG.Tweening;

public class TimeTrialTitle : MonoBehaviour
{
    private Vector3 startSize = new Vector3 (0, 0, 0); 
    private Vector3 EndSize = new Vector3 (1.3f, 1.3f, 1.3f);

    private void Start()
    {
        gameObject.transform.localScale = startSize;
        gameObject.transform.DOScale(EndSize, 3f).SetDelay(.5f);
    }
}
