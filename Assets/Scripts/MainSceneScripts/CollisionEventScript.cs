using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEventScript : MonoBehaviour
{
    public event Action OnPlayerPlaneCollisionDifficultMovementPlane;
    public event Action OnPlayerPlaneCollisionRedZone;
    public event Action OnPlayerPlaneCollisionOrangeZone;
    public event Action OnPlayerPlaneCollisionYellowZone;
    public event Action OnPlayerPlaneCollisionGreenZone;

    public event Action OnPlayerPlaneCollisionMazeEntrance;
    public event Action OnPlayerPlaneCollisionMazeExit;

    public event Action OnPlayerPlaneCollisionEnemySpawningPlane;
    public event Action OnPlayerCollisionEnemy;

    public event Action OnPlayerPlaneCollisionSceneChanger;

    public void CallPlayerPlaneCollisionDifficultMovementPlane()
    {
        OnPlayerPlaneCollisionDifficultMovementPlane?.Invoke();
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
        OnPlayerPlaneCollisionMazeEntrance?.Invoke();
    }

    public void CallPlayerCollisionMazeExit()
    {
        OnPlayerPlaneCollisionMazeExit?.Invoke();
    }

    public void CallPlayerCollisionSceneChanger()
    {
        OnPlayerPlaneCollisionSceneChanger?.Invoke();
    }

    public void CallPlayerCollisionEnemySpawningPlane()
    {
        OnPlayerPlaneCollisionEnemySpawningPlane?.Invoke();
    }

    public void CallPlayerCollisionEnemy()
    {
        OnPlayerCollisionEnemy?.Invoke();
    }

}
