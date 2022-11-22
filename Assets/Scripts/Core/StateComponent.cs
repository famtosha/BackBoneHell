using System.Linq;
using UnityEngine;
using UnityTools.Extentions;

public class StateComponent : MonoBehaviour
{
    [SerializeReference, SubclassSelector] private GameState _state;

    public GameState state => _state;

    public GameSystem[] systems { get; private set; }

    public void FindSystems()
    {
        systems = GetComponentsInChildren<GameSystem>()
            .OrderBy(x => x.transform.GetGlobalSiblingIndexFast())
            .ToArray();
    }
}
