﻿using System;
using System.Linq;
using UnityEngine;
using UnityTools.Extentions;

public class SystemsSolver : MonoBehaviour
{
    private GameData _gameData;
    private StateComponent[] _states;

    private GameSystem[] _systems;

    private UISolver _ui;

    private StateComponent _activeState;
    private StateComponent activeState
    {
        get => _activeState;
        set
        {
            _activeState?.systems.ForEach(x => x.OnStateExit());
            _activeState = value;
            _activeState?.systems.ForEach(x => x.OnStateEnter());
        }
    }

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

    public void SetState<T>() where T : GameState
    {
        activeState = _states.FirstOrDefault(x => x.state is T);
    }

    public T Get<T>() where T : GameSystem
    {
        return _systems.OfType<T>().FirstOrDefault();
    }

    private void UpdateSystems()
    {
        ForeachSystem(x => x.OnUpdate());
    }

    private void LoadSystems()
    {
        _gameData = new GameData();
        ForeachSystem(x => x.gameData = _gameData);
        ForeachSystem(x => x.ui = _ui);
        ForeachSystem(x => x.solver = this);
    }

    private void AwakeSystem()
    {
        ForeachSystem(x => x.OnAwake());
    }

    private void StartSystem()
    {
        ForeachSystem(x => x.OnStart());
    }

    private void ForeachSystem(Action<GameSystem> action)
    {
        foreach (var system in _systems)
        {
            action(system);
        }
    }

    private void FindSystems()
    {
        _states = FindObjectsOfType<StateComponent>();
        _states.ForEach(x => x.FindSystems());
        _systems = _states.SelectMany(x => x.systems).ToArray();
    }
}
