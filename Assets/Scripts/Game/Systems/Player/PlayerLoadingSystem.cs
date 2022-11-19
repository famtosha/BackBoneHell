using System.Linq;
using UnityEngine;

public class PlayerLoadingSystem : GameSystem
{
    public override void OnAwake()
    {
        gameData.player = FindObjectOfType<PlayerComponent>();
        gameData.woldWeaponComponents = FindObjectsOfType<WorldWeaponComponent>().ToList();
    }
}