using System.Linq;

public class PlayerLoadingSystem : GameSystem
{
    public override void OnStateEnter()
    {
        gameData.player = FindObjectOfType<PlayerComponent>();
        gameData.woldWeaponComponents = FindObjectsOfType<WorldWeaponComponent>().ToList();
        GetScreen<SoulCountScreen>().Open();
        gameData.player.transform.position = gameData.level.rooms.FirstOrDefault().position;
        SetState<Game>();
    }
}