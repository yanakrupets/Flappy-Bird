using DG.Tweening;
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

    [Inject] private SoundManager _soundMananger;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private int _spriteNumber = 0;
    private Vector3 _startPosition;
    private bool _isFlying;
    private bool _isRotated;

    public int CurrentPoints { get; set; }

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
            if (_isFlying)
                _soundMananger.PlayWingSound();
            _rigidbody.velocity = Vector2.up * _jumpForce;

            if (!_isRotated && _isFlying)
                StartCoroutine("Rotate");
        }
    }

    IEnumerator Rotate()
    {
        transform.DORotate(new Vector3(0, 0, 45), 0.2f);
        _isRotated = true;

        yield return new WaitForSeconds(0.8f);

        transform.DORotate(new Vector3(0, 0, 0), 0.2f);
        _isRotated = false;
    }

    public void ResetPlayer()
    {
        CurrentPoints = 0;

        transform.position = _startPosition;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void StartFly()
    {
        _isFlying = true;
        _rigidbody.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }

    public void StopFly()
    {
        _isFlying = false;
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
