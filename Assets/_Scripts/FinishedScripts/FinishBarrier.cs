/// <summary>
/// Class to enable barrier when player wlaks over finish line.
/// </summary>
public class FinishBarrier : Barrier
{
    protected override void Start()
    {
        base.Start();
        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += EnableBarrier;
    }
}
