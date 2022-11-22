using System.Collections.Generic;
using UnityEngine;

public class LevelLoadingSystem : GameSystem
{
    private LevelComponent level => gameData.level;
    private List<Room> rooms => level.rooms;

    public override void OnStateEnter()
    {
        LoadLevel();
        GenerateTilemap();
    }

    private void LoadLevel()
    {
        if (level != null)
        {
            Destroy(level.gameObject);
        }
        var levels = Resources.LoadAll<LevelComponent>("Levels");
        var maxLevel = levels.Length - 1;
        var currentLevelID = gameData.currentLevelID;
        var levelID = Mathf.Clamp(currentLevelID, 0, maxLevel);
        gameData.level = Instantiate(levels[levelID]);
    }

    private void GenerateTilemap()
    {
        var steps = new List<GenerationStep>()
        {
            new RoomGenerationStep(),
            new WaysGenerationStep(),
            new WallsGenerationStep(),
            new ItemsGenerationStep(),
        };
        steps.ForEach(x => x.Init(level));
        steps.ForEach(x => x.Invoke());
    }
}
