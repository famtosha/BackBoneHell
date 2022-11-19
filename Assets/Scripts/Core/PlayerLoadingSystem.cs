public class PlayerLoadingSystem : GameSystemBase
{
    public override void OnStart()
    {
        gameData.player = FindObjectOfType<PlayerComponent>();
    }
}