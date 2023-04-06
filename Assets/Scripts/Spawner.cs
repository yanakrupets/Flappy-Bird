using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _time;

    public void StartSpawn()
    {
        InvokeRepeating(nameof(Spawn), _time, _time);
    }

    private void Spawn()
    {
        var element = Instantiate(_prefab, transform.position, Quaternion.identity);
        element.transform.SetParent(transform);
        element.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
    }
}
