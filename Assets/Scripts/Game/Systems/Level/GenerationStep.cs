using System.Collections.Generic;
using UnityEngine;

public abstract class GenerationStep
{
    private LevelComponent _level;

    protected LevelComponent level => _level;
    protected List<Vector2> rooms => _level.rooms;

    public void Init(LevelComponent levelComponent)
    {
        _level = levelComponent;
    }

    public abstract void Invoke();
}
