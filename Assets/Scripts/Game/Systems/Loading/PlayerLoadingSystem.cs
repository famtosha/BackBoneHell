using System.Linq;

public class PlayerLoadingSystem : GameSystem
{
    public override void OnStateEnter()
    {
        gameData.player = FindObjectOfType<PlayerComponent>();
        GetScreen<SoulCountScreen>().Open();
        gameData.woldWeaponComponents = FindObjectsOfType<WorldWeaponComponent>().ToList();
        gameData.player.transform.position = gameData.level.rooms.FirstOrDefault().position;
        SetState<Game>();
    }
}