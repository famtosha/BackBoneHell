using System.Linq;
using UnityEngine;
using UnityTools.Extentions;

public class SystemsSolver : MonoBehaviour
{
    private GameData _gameData;
    private GameSystem[] _gameSystems;

    private UISolver ui;

    private void Awake()
    {
        ui = FindObjectOfType<UISolver>();
        ui.screens.ForEach(x => x.Close());
        FindSystems();
        LoadSystems();
        AwakeSystem();
    }

    private void Start()
    {
        StartSystem();
    }

    private void Update()
    {
        UpdateSystems();
    }

    private void OnEnable()
    {
        _gameSystems.ForEach(x => x.Enabled());
    }

    private void OnDisable()
    {
        _gameSystems.ForEach(x => x.Disable());
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

    private void AwakeSystem()
    {
        _gameSystems.ForEach(x => x.OnAwake());
    }

    private void StartSystem()
    {
        _gameSystems.ForEach(x => x.OnStart());
    }

    private void FindSystems()
    {
        _gameSystems = GetComponentsInChildren<GameSystem>()
            .OrderBy(x => x.transform.GetGlobalSiblingIndexFast())
            .ToArray();
    }
}
