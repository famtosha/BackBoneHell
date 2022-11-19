using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public PlayerComponent player;
    public List<WorldWeaponComponent> woldWeaponComponents;
    public List<WeaponProjectileComponent> projectiles = new List<WeaponProjectileComponent>();
}