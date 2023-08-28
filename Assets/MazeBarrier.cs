using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBarrier : Barrier
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += EnableBarrier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
