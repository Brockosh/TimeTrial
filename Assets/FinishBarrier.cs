using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBarrier : Barrier
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += EnableBarrier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
