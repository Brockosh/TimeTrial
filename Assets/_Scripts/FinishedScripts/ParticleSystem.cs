using UnityEngine;
/// <summary>
/// Class to control the activation of fog particle system in obstacle 4.
/// </summary>
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
