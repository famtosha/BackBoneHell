using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Rooms : List<Room>
{
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