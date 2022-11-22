using System.Linq;
using UnityEngine;
using UnityTools.Extentions;

public class WaysGenerationStep : GenerationStep
{
    public override void Invoke()
    {
        SpawnWays();
    }

    private void SpawnWays()
    {
        foreach (var room in rooms)
        {
            var temp = rooms.OrderBy(otherRoom => Vector3.Distance(room.position, otherRoom.position));
            temp.Skip(1).Take(2).ForEach(x => SpawnWayX(x.position, room.position));
        }
    }

    private void SpawnWayX(Vector2 pointA, Vector2 pointB)
    {
        if (pointB.x < pointA.x)
        {
            var temp = pointB;
            pointB = pointA;
            pointA = temp;
        }

        int start = Mathf.RoundToInt(pointA.x);
        int end = Mathf.RoundToInt(pointB.x);

        var eq = GetEq(pointA, pointB);

        if (eq.b != 0)
        {
            for (int x = start; x < end; x++)
            {
                var y = Mathf.RoundToInt((-eq.c - eq.a * x) / eq.b);
                var point = new Vector3Int(x, y, 0);
                SetBlocks(point);
            }
        }
    }

    private (float a, float b, float c) GetEq(Vector2 pointA, Vector2 pointB)
    {
        float a = pointA.y - pointB.y;
        float b = pointB.x - pointA.x;
        float c = pointA.x * pointB.y - pointB.x * pointA.y;
        return (a, b, c);
    }

    private void SetBlocks(Vector3Int point)
    {
        SetBlock(point, 0, 0);

        SetBlock(point, -1, 0);
        SetBlock(point, 1, 0);
        SetBlock(point, 0, -1);
        SetBlock(point, 0, 1);

        SetBlock(point, 1, 1);
        SetBlock(point, -1, -1);
        SetBlock(point, 1, -1);
        SetBlock(point, -1, 1);
    }

    private void SetBlock(Vector3Int point, int x, int y)
    {
        level.floorTilemap.SetTile(point + new Vector3Int(x, y, 0), level.tilesConfig.floorTile);
    }
}
