using System.Linq;
using UnityEngine;
using UnityTools.Extentions;

public class SystemsSolver : MonoBehaviour
{
    private GameData _gameData;
    private GameSystemBase[] _gameSystems;

    private void Awake()
    {
        FindSystems();
        LoadSystems();
    }

    private void Start()
    {
        StartSystems();
    }

    private void Update()
    {
        UpdateSystems();
    }

    private void UpdateSystems()
    {
        _gameSystems.ForEach(x => x.OnUpdate());
    }

    private void LoadSystems()
    {
        _gameData = new GameData();
        _gameSystems.ForEach(x => x.gameData = _gameData);
    }

    private void StartSystems()
    {
        _gameSystems.ForEach(x => x.OnStart());
    }

    private void FindSystems()
    {
        _gameSystems = GetComponentsInChildren<GameSystemBase>()
            .OrderBy(x => x.transform.GetGlobalSiblingIndexFast())
            .ToArray();
    }
}
