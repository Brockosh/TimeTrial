/// <summary>
/// Inherited from Barrier, enables door barrier when player colliders with set collider.
/// </summary>
public class DoorBarrier : Barrier
{
    protected override void Start()
    {
        base.Start();
        GameManager.instance.CollisionEvent.OnPlayerCollisionDoorBarrier += EnableBarrier;
    }
}
