public class MazeBarrier : Barrier
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += EnableBarrier;
    }
}