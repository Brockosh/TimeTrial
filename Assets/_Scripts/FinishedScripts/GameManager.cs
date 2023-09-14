using UnityEngine;
/// <summary>
/// Class to call events and monitor for player quit if escape key is pressed.
/// </summary>
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            Application.Quit();
        }
    }
}
