using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoveBackground : MonoBehaviour 
{
	[SerializeField] private float _speed;
	[SerializeField] private float _destinationPosition;
	[SerializeField] private float _startPosition;

	private float x;
	private bool _isMoving;

	private void Awake()
	{
		EventManager.AddListener<StartMovingBackgroundEvent>(ContinueMovement);
		EventManager.AddListener<StopSpawnEvent>(StopMovement);
	}

    void Update () 
	{
		if (_isMoving)
        {
			x = transform.position.x;
			x += _speed * Time.deltaTime;
			transform.position = new Vector3(x, transform.position.y, transform.position.z);
		}

		if (x <= _destinationPosition) 
		{
			x = _startPosition;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}
	}

	private void StopMovement(StopSpawnEvent evt) => _isMoving = false;

	private void ContinueMovement(StartMovingBackgroundEvent evt) => _isMoving = true;
}
