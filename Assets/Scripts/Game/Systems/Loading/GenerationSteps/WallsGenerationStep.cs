using System.Drawing;
using System.Reflection;
using UnityEngine;

public class WallsGenerationStep : GenerationStep
{
    public override void Invoke()
    {
        SpawnWalls();
    }

    private void SpawnWalls()
    {
        level.Foreach(new RectInt(-30, -30, 60, 60), (point) =>
        {
            if (level.floorTilemap.GetTile(point) == level.floorTile)
            {
                Produce(point, 0, 1);
                Produce(point, 0, -1);
                Produce(point, 1, 0);
                Produce(point, -1, 0);

                Produce(point, 1, 1);
                Produce(point, 1, -1);
                Produce(point, -1, 1);
                Produce(point, -1, -1);
            }
        });
    }

    private void Produce(Vector3Int pos, int x, int y)
    {
        Produce(pos + new Vector3Int(x, y, 0));
    }

    private void Produce(Vector3Int pos)
    {
        if (level.floorTilemap.GetTile(pos) == null)
        {
            level.wallTilemap.SetTile(pos, level.wallTile);
        }
    }
}
