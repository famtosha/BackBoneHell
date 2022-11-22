public class EnemyDeathSystem : GameSystem
{
    private Enemyes enemyes => gameData.level.enemyes;

    public override void OnStateEnter()
    {
        enemyes.enemyes.ForEach(x => x.Death.AddListener(OnEnemyDeath));
        enemyes.EnemyAdded.AddListener(x => x.Death.AddListener(OnEnemyDeath));
    }

    public override void OnStateExit()
    {
        enemyes.EnemyAdded.AddListener(x => x.Death.RemoveListener(OnEnemyDeath));
    }

    private void OnEnemyDeath(EnemyComponent enemy)
    {
        gameData.soulCount.count += enemy.soulCount;
        gameData.level.enemyes.Remove(enemy);
    }
}
