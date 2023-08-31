public class DoorBarrier : Barrier
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        GameManager.instance.CollisionEvent.OnPlayerCollisionDoorBarrier += EnableBarrier;
    }
}
