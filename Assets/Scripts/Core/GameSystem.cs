using UnityEngine;

public abstract class GameSystem : MonoBehaviour
{
    public GameData gameData { get; set; }

    public virtual void OnAwake() { }
    public virtual void OnStart() { }
    public virtual void OnUpdate() { }
    public virtual void Disable() { }
    public virtual void Enabled() { }
}