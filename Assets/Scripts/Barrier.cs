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

    private void Awake()
    {
        EventManager.AddListener<StopMovementEvent>(StopMovement);
        EventManager.AddListener<ContinueMovementEvent>(ContinueMovement);
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
            Destroy(gameObject);
        }
    }

    public void StopMovement(StopMovementEvent evt) => _isMoving = false;

    public void ContinueMovement(ContinueMovementEvent evt) => _isMoving = true;
}
