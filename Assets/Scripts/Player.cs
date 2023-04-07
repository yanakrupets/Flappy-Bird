using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Inject] private EventManager _eventManager;

    [SerializeField] private float _jumpForce = 0;
    [SerializeField] private Sprite[] _flySprites;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private int _spriteNumber = 0;
    private int _currentPoints;

    public int CurrentPoints => _currentPoints;

    private void Awake()
    {
        _eventManager.AddListener<StopMovementEvent>(StopFly);
        _eventManager.AddListener<ContinueMovementEvent>(StartFly);
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _currentPoints = 0;

        InvokeRepeating(nameof(FlyAnimation), 0.15f, 0.15f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Passage")
        {
            _currentPoints++;
            Debug.Log("Passage");
        }

        if (other.gameObject.tag == "Barrier")
        {
            // trigger event
            Debug.Log("Barrier");
        }
    }
}
