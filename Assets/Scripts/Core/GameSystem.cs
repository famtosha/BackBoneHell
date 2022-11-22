using UnityEngine;

public abstract class GameSystem : MonoBehaviour
{
    public SystemsSolver solver { get; set; }
    public GameData gameData { get; set; }
    public UISolver ui { get; set; }

    public virtual void OnStart() { }
    public virtual void OnUpdate() { }
    public virtual void OnStateExit() { }
    public virtual void OnStateEnter() { }

    protected T GetScreen<T>() where T : UIScreen
    {
        return ui.Get<T>();
    }

    protected T GetSystem<T>() where T : GameSystem
    {
        return solver.Get<T>();
    }

    protected void SetState<T>() where T : GameState
    {
        solver.SetState<T>();
    }
}