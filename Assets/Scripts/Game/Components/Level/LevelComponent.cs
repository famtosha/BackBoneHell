using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelComponent : MonoBehaviour
{
    [field: SerializeField] public Tilemap floorTilemap { get; private set; }
    [field: SerializeField] public Tilemap wallTilemap { get; private set; }

    [field: SerializeField] public LevelTiles tilesConfig { get; private set; }

    [field: SerializeField] public WorldWeaponComponent weapon { get; private set; }
    [field: SerializeField] public EnemyComponent enemy { get; private set; }

    public readonly Rooms rooms = new Rooms();
    public readonly Enemyes enemyes = new Enemyes();
}
