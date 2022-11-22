using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelComponent : MonoBehaviour
{
    [field: SerializeField] public Tilemap floorTilemap { get; private set; }
    [field: SerializeField] public Tilemap wallTilemap { get; private set; }

    [field: SerializeField] public Tile floorTile { get; private set; }
    [field: SerializeField] public Tile wallTile { get; private set; }

    [field: SerializeField] public WorldWeaponComponent weapon { get; private set; }
    [field: SerializeField] public EnemyComponent enemy { get; private set; }

    public readonly Rooms rooms = new Rooms();
    public readonly Enemyes enemyes = new Enemyes();

    public void Foreach(RectInt rect, Action<Vector3Int> action)
    {
        for (int x = rect.xMin; x < rect.xMax; x++)
        {
            for (int y = rect.yMin; y < rect.yMax; y++)
            {
                var position = new Vector3Int(x, y, 0);
                action(position);
            }
        }
    }
}
