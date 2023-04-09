using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolCount;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _time;

    [Inject] private DiContainer _diContainer;

    private Queue<GameObject> _currentBarriers;

    private void Awake()
    {
        EventManager.AddListener<StopMovementEvent>(StopSpawn);
        EventManager.AddListener<ContinueMovementEvent>(StartSpawn);
    }

    private void Start()
    {
        _currentBarriers = new Queue<GameObject>();

        for (var i = 0; i < _poolCount; i++)
        {
            var prefab = _diContainer.InstantiatePrefab(_prefab, transform.position, Quaternion.identity, transform);
            prefab.SetActive(false);
            _currentBarriers.Enqueue(prefab);
        }

        Barrier.OnRemove += ReturnBarrier;
    }

    public void StartSpawn(ContinueMovementEvent evt)
    {
        InvokeRepeating(nameof(Spawn), _time, _time);
    }

    public void StopSpawn(StopMovementEvent evt)
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        var barrier = _currentBarriers.Dequeue();
        barrier.SetActive(true);
        barrier.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
    }

    public void ReturnBarrier(GameObject barrier)
    {
        barrier.transform.position = transform.position;
        barrier.SetActive(false);
        _currentBarriers.Enqueue(barrier);
    }
}
