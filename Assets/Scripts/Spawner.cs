using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _time;

    [Inject] private EventManager _eventManager;
    [Inject] private DiContainer _diContainer;

    private void Awake()
    {
        _eventManager.AddListener<StopMovementEvent>(StopSpawn);
        _eventManager.AddListener<ContinueMovementEvent>(Spawn);
    }

    public void StartSpawn()
    {
        InvokeRepeating(nameof(Spawn), _time, _time);
    }

    public void Spawn(ContinueMovementEvent evt)
    {
        StartSpawn();
    }

    public void StopSpawn(StopMovementEvent evt)
    {
        CancelInvoke(nameof(Spawn));
    }

    public void Spawn()
    {
        var element = _diContainer.InstantiatePrefab(_prefab, transform.position, Quaternion.identity, transform);
        element.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
    }
}
