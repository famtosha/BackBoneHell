using System;
using UnityEngine;

[Serializable]
public class Room
{
    public Vector2 position;

    public Room(Vector2 position)
    {
        this.position = position;
    }
}
