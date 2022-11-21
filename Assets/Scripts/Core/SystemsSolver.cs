using System.Linq;
using UnityEngine;
using UnityTools.Extentions;

public class SystemsSolver : MonoBehaviour
{
    private GameData _gameData;
    private GameSystem[] _gameSystems;

    private UISolver _ui;

    private void Awake()
    {
        FindSystems();
        FindUI();

        LoadSystems();
        LoadUI();
        AwakeSystem();
    }

    private void LoadUI()
    {
        _ui.screens.ForEach(x => x.OnAwake());
        _ui.screens.ForEach(x => x.Close());
    }

    private void FindUI()
    {
        _ui = FindObjectOfType<UISolver>();
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

    public T Get<T>() where T : GameSystem
    {
        return _gameSystems.OfType<T>().FirstOrDefault();
    }

    private void UpdateSystems()
    {
        _gameSystems.ForEach(x => x.OnUpdate());
    }

    private void LoadSystems()
    {
        _gameData = new GameData();
        _gameSystems.ForEach(x => x.gameData = _gameData);
        _gameSystems.ForEach(x => x.ui = _ui);
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
