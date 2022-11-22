using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomGenerationStep : GenerationStep
{
    public override void Invoke()
    {
        SpawnRooms();
    }

    private void SpawnRooms()
    {
        for (int x = -20; x < 20; x++)
        {
            for (int y = -20; y < 20; y++)
            {
                var position = new Vector2(x, y);
                var noiseCoords = new Vector2(
                    (x + 100 + Random.Range(0, 20)) / 15f,
                    (y + 100 + Random.Range(0, 20)) / 15f);
                var noiseValue = Mathf.PerlinNoise(noiseCoords.x, noiseCoords.y);
                var validDistance = !rooms.Any(room => Vector3.Distance(room.position, position) < 10);
                if (noiseValue > 0.75f && validDistance)
                {
                    var room = SpawnRoomSimple(x, y);
                    rooms.Add(new Room(room.center));
                }
            }
        }
    }

    private RectInt SpawnRoomSimple(int x, int y)
    {
        var rect = new RectInt(x, y, 7, 7);
        SpawnRoom(rect);
        return rect;
    }

    private void SpawnRoom(RectInt rect)
    {
        SpawnFloor(rect, level.floorTilemap);
    }

    private void SpawnFloor(RectInt rect, Tilemap map)
    {
        level.Foreach(rect, (position) =>
        {
            map.SetTile(position, level.floorTile);
        });
    }
}
