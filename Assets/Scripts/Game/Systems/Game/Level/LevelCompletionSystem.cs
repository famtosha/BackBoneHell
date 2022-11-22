using System.Diagnostics;
using UnityEngine;

public class LevelCompletionSystem : GameSystem
{
    private Enemyes enmeyes => gameData.level.enemyes;

    public override void OnStateEnter()
    {
        enmeyes.CountChanged.AddListener(CheckComplete);
    }

    public override void OnStateExit()
    {
        enmeyes.CountChanged.RemoveListener(CheckComplete);
    }

    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Complete();
        }
    }

    private void CheckComplete()
    {
        if (enmeyes.enemyes.Count <= 0)
        {
            Complete();
        }
    }

    private void Complete()
    {
        gameData.currentLevelID++;
        SetState<Loading>();
    }
}
