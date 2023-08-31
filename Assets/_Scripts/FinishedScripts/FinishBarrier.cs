public class FinishBarrier : Barrier
{
    protected override void Start()
    {
        base.Start();
        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += EnableBarrier;
    }
}
