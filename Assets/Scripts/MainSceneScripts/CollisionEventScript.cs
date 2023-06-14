using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEventScript : MonoBehaviour

{
    
    public event Action OnPlayerCollisionStartLine;
    public event Action OnPlayerCollisionFinishLine;
    public event Action OnPlayerCollisionDifficultMovementPlane;
    public event Action OnPlayerCollisionDifficultMovementPlaneExit;
    public event Action OnPlayerCollisionDifficultMovementPlaneRespawn;
    public event Action OnPlayerPlaneCollisionRedZone;
    public event Action OnPlayerPlaneCollisionOrangeZone;
    public event Action OnPlayerPlaneCollisionYellowZone;
    public event Action OnPlayerPlaneCollisionGreenZone;


    public event Action OnPlayerCollisionCorrectDoor;

    public event Action OnPlayerCollisionMazeEntrance;
    public event Action OnPlayerCollisionMazeExit;

    public event Action OnPlayerCollisionEnemySpawningPlane;
    public event Action OnPlayerCollisionEnemySpawningPlaneExit;


    public event Action OnPlayerCollisionMathsLevel;


    public event Action OnPlayerCollisionEnemy;

    public event Action OnPlayerPlaneCollisionSceneChanger;

    public void CallPlayerPlaneCollisionDifficultMovementPlane()
    {
        OnPlayerCollisionDifficultMovementPlane?.Invoke();
    }

    public void CallPlayerPlaneCollisionDifficultMovementPlaneExit()
    {
        OnPlayerCollisionDifficultMovementPlaneExit?.Invoke();
    }

    public void CallPlayerCollisionRedZone()
    {
        OnPlayerPlaneCollisionRedZone?.Invoke();
    }

    public void CallPlayerCollisionOrangeZone()
    {
        OnPlayerPlaneCollisionOrangeZone?.Invoke();
    }

    public void CallPlayerCollisionYellowZone()
    {
        OnPlayerPlaneCollisionYellowZone?.Invoke();
    }

    public void CallPlayerCollisionGreenZone()
    {
        OnPlayerPlaneCollisionGreenZone?.Invoke();
    }

    public void CallPlayerCollisionMazeEntrance()
    {
        OnPlayerCollisionMazeEntrance?.Invoke();
    }

    public void CallPlayerCollisionMazeExit()
    {
        OnPlayerCollisionMazeExit?.Invoke();
    }

    public void CallPlayerCollisionSceneChanger()
    {
        OnPlayerPlaneCollisionSceneChanger?.Invoke();
    }

    public void CallPlayerCollisionEnemySpawningPlane()
    {
        OnPlayerCollisionEnemySpawningPlane?.Invoke();
    }

    public void CallPlayerCollisionEnemySpawningPlaneExit()
    {
        OnPlayerCollisionEnemySpawningPlaneExit?.Invoke();
    }

    public void CallPlayerCollisionEnemy()
    {
        OnPlayerCollisionEnemy?.Invoke();
    }

    public void CallPlayerCollisionMathsLevel()
    {
        OnPlayerCollisionMathsLevel?.Invoke();
        Debug.Log("Called Collision Maths Level");
    }

    public void CallPlayerCollisionStartLine()
    {
        OnPlayerCollisionStartLine?.Invoke();
    }

    public void CallPlayerCollisionFinishLine()
    {
        OnPlayerCollisionFinishLine?.Invoke();
    }

    public void CallPlayerCollisionCorrectDoor()
    {
        OnPlayerCollisionCorrectDoor?.Invoke();
    }

    public void CallPlayerCollisionDifficultMovementPlaneRespawn()
    {
        OnPlayerCollisionDifficultMovementPlaneRespawn?.Invoke();
    }

}
