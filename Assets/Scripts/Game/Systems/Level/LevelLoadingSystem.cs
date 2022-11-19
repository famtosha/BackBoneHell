using UnityEngine;

public class LevelLoadingSystem : GameSystem
{
    public override void OnAwake()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        var levels = Resources.LoadAll<LevelComponent>("Levels");
        var maxLevel = levels.Length - 1;
        var currentLevelID = gameData.currentLevelID;
        var levelID = Mathf.Clamp(currentLevelID, 0, maxLevel);
        gameData.level = Instantiate(levels[levelID]);
    }
}
