using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Barrier : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    private float _removalEdge;

    private bool _isMoving;

    public static Action<GameObject> OnRemove;

    private void Awake()
    {
        EventManager.AddListener<StopMovementEvent>(StopMovement);
        EventManager.AddListener<ContinueMovementEvent>(ContinueMovement);
        EventManager.AddListener<ReturnToPoolEvent>(ReturnToPool);
    }

    void Start()
    {
        _removalEdge = (Camera.main.ScreenToWorldPoint(Vector3.zero) + new Vector3(-1, 0, 0)).x;
        _isMoving = true;
    }

    void Update()
    {
        if (_isMoving)
            transform.position += Vector3.left * _speed * Time.deltaTime;

        if (transform.position.x < _removalEdge)
        {
            OnRemove(gameObject);
        }
    }

    public void ReturnToPool(ReturnToPoolEvent evt) => OnRemove(gameObject);

    public void StopMovement(StopMovementEvent evt) => _isMoving = false;

    public void ContinueMovement(ContinueMovementEvent evt) => _isMoving = true;
}
