using UnityEngine;

public class Barrier : MonoBehaviour
{
    protected virtual void Start()
    {
        DisableBarrier();
    }
    protected void EnableBarrier()
    {
        gameObject.SetActive(true);
    }

    private void DisableBarrier()
    {
        gameObject.SetActive(false);
    }
}
