using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CollisionEventScript CollisionEvent;
    public GameEvents gameEvents;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}