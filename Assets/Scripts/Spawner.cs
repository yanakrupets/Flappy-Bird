using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _time;

    private void OnEnable()
    {
        transform.position = new Vector3(
            (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)) + new Vector3(1, 0, 0)).x, 
            transform.position.y,
            transform.position.z);

        InvokeRepeating(nameof(Spawn), _time, _time);
    }

    private void OnDisable()
    {
        // CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        var element = Instantiate(_prefab, transform.position, Quaternion.identity);
        element.transform.SetParent(transform);
        element.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
    }
}
