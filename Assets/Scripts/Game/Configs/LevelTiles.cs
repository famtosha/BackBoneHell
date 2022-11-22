using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Generation/LevelTiles")]
public class LevelTiles : ScriptableObject
{
    [field: SerializeField, ShowAssetPreview] public TileBase floorTile { get; private set; }
    [field: SerializeField, ShowAssetPreview] public TileBase wallTile { get; private set; }
}
