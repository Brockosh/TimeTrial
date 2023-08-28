using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public CollisionEventScript CollisionEvent;
    public MathEvents mathEvents;
    public GameEvents gameEvents;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    //1. Referring to Q1, is there something I can do other than changing the name of the GameManager script to make it run its awake first?
    //2. How can I make my player rotate the appropriate direction, and reflect that in the first person camera in the maze?
    //3. Setting up the state manager
}
