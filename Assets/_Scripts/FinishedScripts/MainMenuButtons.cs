using DG.Tweening;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    private Vector3 startSize = new Vector3(0, 0, 0);
    private Vector3 EndSize = new Vector3(1f, 1f, 1f);

    public void ScaleUpAnimation()
    {
        gameObject.transform.localScale = startSize;
        gameObject.transform.DOScale(EndSize, 3f).SetDelay(.5f);
    }

    private void Start()
    {
        ScaleUpAnimation();
    }
}
