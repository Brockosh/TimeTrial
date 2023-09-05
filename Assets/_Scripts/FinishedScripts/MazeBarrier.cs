public class MazeBarrier : Barrier
{
    protected override void Start()
    {
        base.Start();
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += EnableBarrier;
    }
}