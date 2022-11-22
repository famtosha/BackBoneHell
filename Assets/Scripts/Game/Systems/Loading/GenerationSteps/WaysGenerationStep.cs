using System.Linq;
using UnityEngine;
using UnityEngine.UI;
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
        Debug.DrawLine(pointA, pointB, Color.red, 5);
        if (pointB.x < pointA.x)
        {
            var temp = pointB;
            pointB = pointA;
            pointA = temp;
        }

        var eq = GetEq(pointA, pointB);
        var rect = GetRect(pointA, pointB);

        if (eq.b != 0)
        {
            level.rooms.Foreach(rect, (position) =>
            {
                var lineY = Mathf.RoundToInt((-eq.c - eq.a * position.x) / eq.b);
                var linePosition = new Vector3(position.x, lineY,0);
                if (Mathf.Abs(lineY - position.y) < 3)
                {
                    SetBlocks(position);
                    Debug.DrawLine(position, linePosition, Color.magenta, 5);
                }
                else
                {
                    Debug.DrawLine(position, linePosition, Color.cyan, 5);
                }
            });
        }
    }

    private RectInt GetRect(Vector2 pointA, Vector2 pointB)
    {
        var result = new RectInt();
        result.xMin = (int)Mathf.Min(pointA.x, pointB.x);
        result.yMin = (int)Mathf.Min(pointA.y, pointB.y);

        result.xMax = (int)Mathf.Max(pointA.x, pointB.x);
        result.yMax = (int)Mathf.Max(pointA.y, pointB.y);
        return result;
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

        //SetBlock(point, -1, 0);
        //SetBlock(point, 1, 0);
        //SetBlock(point, 0, -1);
        //SetBlock(point, 0, 1);

        //SetBlock(point, 1, 1);
        //SetBlock(point, -1, -1);
        //SetBlock(point, 1, -1);
        //SetBlock(point, -1, 1);
    }

    private void SetBlock(Vector3Int point, int x, int y)
    {
        level.floorTilemap.SetTile(point + new Vector3Int(x, y, 0), level.tilesConfig.floorTile);
    }
}
