using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;

    private float _removalEdge;

    void Start()
    {
        _removalEdge = (Camera.main.ScreenToWorldPoint(Vector3.zero) + new Vector3(-1, 0, 0)).x;
    }

    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;

        if (transform.position.x < _removalEdge)
        {
            Destroy(gameObject);
        }
    }
}
