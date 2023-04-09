using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 0;
    [SerializeField] private Sprite[] _flySprites;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private int _spriteNumber = 0;
    private Vector3 _startPosition;

    public int CurrentPoints { get; set; }

    private void Awake()
    {
        EventManager.AddListener<StopMovementEvent>(StopFly);
        EventManager.AddListener<ContinueMovementEvent>(StartFly);
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        CurrentPoints = 0;
        _startPosition = transform.position;

        InvokeRepeating(nameof(FlyAnimation), 0.15f, 0.15f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }

    public void ResetPlayer()
    {
        CurrentPoints = 0;

        transform.position = _startPosition;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void Fly()
    {
        _rigidbody.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }

    public void StartFly(ContinueMovementEvent evt)
    {
        Fly();
    }

    public void StopFly(StopMovementEvent evt)
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void FlyAnimation()
    {
        _spriteRenderer.sprite = _flySprites[_spriteNumber];

        _spriteNumber++;
        if (_spriteNumber >= _flySprites.Length)
            _spriteNumber = 0;
    }
}
