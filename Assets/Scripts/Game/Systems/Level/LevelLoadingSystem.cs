using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityTools.Extentions;

public class LevelLoadingSystem : GameSystem
{
    private LevelComponent level => gameData.level;
    private List<Vector2> rooms => level.rooms;

    public override void OnAwake()
    {
        LoadLevel();
        GenerateTilemap();
    }

    public override void OnStart()
    {
        gameData.player.transform.position = rooms.First();
        FindObjectOfType<EnemyComponent>().transform.position = rooms.GetRandom();
    }

    private void LoadLevel()
    {
        var levels = Resources.LoadAll<LevelComponent>("Levels");
        var maxLevel = levels.Length - 1;
        var currentLevelID = gameData.currentLevelID;
        var levelID = Mathf.Clamp(currentLevelID, 0, maxLevel);
        gameData.level = Instantiate(levels[levelID]);
    }

    private void GenerateTilemap()
    {
        var step = new List<GenerationStep>();
        step.Add(new RoomGenerationStep());
        step.Add(new WaysGenerationStep());
        step.Add(new WallsGenerationStep());

        step.ForEach(x => x.Init(level));
        step.ForEach(x => x.Invoke());
    }
}
