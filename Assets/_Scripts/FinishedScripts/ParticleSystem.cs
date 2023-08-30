using UnityEngine;

public class ParticleSystem : MonoBehaviour
{
    private void Start()
    {
        Deactivate();
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += SetActive;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += Deactivate;
    }

    private void SetActive()
    {
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
