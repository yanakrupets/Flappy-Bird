using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 0;
    [SerializeField] private Sprite[] _flySprites;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private int _spriteNumber = 0;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        InvokeRepeating(nameof(Fly), 0.15f, 0.15f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }

    private void Fly()
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
            Debug.Log("Passage");
        }

        if (other.gameObject.tag == "Barrier")
        {
            Debug.Log("Barrier");
        }
    }
}
