using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Spawner : MonoBehaviour
{
    [Inject] protected DiContainer _diContainer;

    private void Awake()
    {
        EventManager.AddListener<StopSpawnEvent>(StopSpawn);
        EventManager.AddListener<StartSpawnEvent>(StartSpawn);
    }

    public abstract void StartSpawn(StartSpawnEvent evt);

    public abstract void StopSpawn(StopSpawnEvent evt);
}
