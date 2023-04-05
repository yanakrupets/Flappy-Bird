using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour 
{
	[SerializeField] private float _speed;
	[SerializeField] private float _destinationPosition;
	[SerializeField] private float _startPosition;

	private float x;

	void Update () 
	{
		x = transform.position.x;
		x += _speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		if (x <= _destinationPosition) 
		{
			x = _startPosition;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}
	}
}
