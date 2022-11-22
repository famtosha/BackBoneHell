using System;
using UnityEngine;

[Serializable]
public class Room
{
    [field: SerializeField] public Vector2 position { get; private set; }

    public Room(Vector2 position)
    {
        this.position = position;
    }
}
