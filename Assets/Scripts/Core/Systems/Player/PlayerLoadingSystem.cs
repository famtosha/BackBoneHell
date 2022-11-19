using System.Linq;

public class PlayerLoadingSystem : GameSystem
{
    public override void OnAwake()
    {
        gameData.player = FindObjectOfType<PlayerComponent>();
        gameData.woldWeaponComponents = FindObjectsOfType<WorldWeaponComponent>().ToList();
    }
}