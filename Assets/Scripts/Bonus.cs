using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bonus : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;

    private BonusData _data;
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

    public void Initialization(BonusData data)
    {
        _data = data;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _data.Sprite;
        spriteRenderer.size = Vector2.one;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.CurrentPoints += _data.Points;

            var bestScore = PlayerPrefs.GetInt(PlayerPrefsConsts.BEST_SCORE);
            bestScore = player.CurrentPoints > bestScore ? player.CurrentPoints : bestScore;
            PlayerPrefs.SetInt(PlayerPrefsConsts.BEST_SCORE, bestScore);

            var pointevent = Events.PointEvent;
            pointevent.point = _data.Points;
            EventManager.Broadcast(pointevent);

            var bonusEvent = Events.BonusEvent;
            bonusEvent.bonusData = _data;
            EventManager.Broadcast(bonusEvent);

            OnRemove(gameObject);
        }
        else if (other.TryGetComponent<Pipe>(out Pipe pipe))
        {
            OnRemove(gameObject);
        }
    }

    public void ReturnToPool(ReturnToPoolEvent evt) => OnRemove(gameObject);

    public void StopMovement(StopMovementEvent evt) => _isMoving = false;

    public void ContinueMovement(ContinueMovementEvent evt) => _isMoving = true;
}
