using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Generation/LevelTiles")]
public class LevelTiles : ScriptableObject
{
    [field: SerializeField, ShowAssetPreview] public Tile floorTile { get; private set; }
    [field: SerializeField, ShowAssetPreview] public Tile wallTile { get; private set; }
}
