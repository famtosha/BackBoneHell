using System;
using System.Collections.Generic;
using UnityEngine.Events;

[Serializable]
public class Enemyes
{
    public readonly UnityEvent CountChanged = new UnityEvent();

    public readonly UnityEvent<EnemyComponent> EnemyAdded = new UnityEvent<EnemyComponent>();
    public readonly UnityEvent<EnemyComponent> EnemyRemoved = new UnityEvent<EnemyComponent>();

    public readonly List<EnemyComponent> enemyes = new List<EnemyComponent>();

    public void Add(EnemyComponent enemy)
    {
        enemyes.Add(enemy);
        CountChanged?.Invoke();
        EnemyAdded?.Invoke(enemy);
    }

    public void Remove(EnemyComponent enemy)
    {
        enemyes.Remove(enemy);
        CountChanged?.Invoke();
        EnemyRemoved?.Invoke(enemy);
    }
}
