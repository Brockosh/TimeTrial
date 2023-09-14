/// <summary>
/// Inherited class enabling barrier when player enters the maze, preventing exit.
/// </summary>
public class MazeBarrier : Barrier
{
    protected override void Start()
    {
        base.Start();
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += EnableBarrier;
    }
}