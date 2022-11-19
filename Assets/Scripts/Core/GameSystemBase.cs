using UnityEngine;

public abstract class GameSystemBase : MonoBehaviour
{
    public GameData gameData { get; set; }

    public virtual void OnStart()
    {

    }

    public virtual void OnUpdate()
    {

    }
}
