using UnityEngine;

public abstract class GameSystem : MonoBehaviour
{
    public GameData gameData { get; set; }
    public UISolver ui { get; set; }

    public virtual void OnAwake() { }
    public virtual void OnStart() { }
    public virtual void OnUpdate() { }
    public virtual void Disable() { }
    public virtual void Enabled() { }

    protected T GetScreen<T>() where T : UIScreen
    {
        return ui.Get<T>();
    }

    protected T GetSystem<T>() where T : GameSystem
    {
        return FindObjectOfType<SystemsSolver>().Get<T>();
    }
}