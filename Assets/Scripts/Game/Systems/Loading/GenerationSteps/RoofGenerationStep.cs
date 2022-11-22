using UnityEngine;

public class RoofGenerationStep : GenerationStep
{
    public override void Invoke()
    {
        level.rooms.Foreach(new RectInt(-50, -50, 100, 100), (position) =>
        {
            var floorTile = level.floorTilemap.GetTile(position);
            var wallTile = level.wallTilemap.GetTile(position);
            if (floorTile == null && wallTile == null)
            {
                level.wallTilemap.SetTile(position, level.tilesConfig.wallTile);
            }
        });

        level.rooms.Foreach(new RectInt(-50, -50, 100, 100), (position) =>
        {
            level.floorTilemap.SetTile(position, level.tilesConfig.floorTile);
        });
    }
}
