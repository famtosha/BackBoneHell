using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public int currentLevelID;
    public LevelComponent level;
    public PlayerComponent player;
    public List<WorldWeaponComponent> woldWeaponComponents;
    public List<WeaponProjectileComponent> projectiles = new List<WeaponProjectileComponent>();

    public Wallet soulCount = new Wallet();
}
