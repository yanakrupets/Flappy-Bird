using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Pipe : MonoBehaviour
{
    [Inject] private GameManager _gameManager;
    [Inject] private SoundManager _soundManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _soundManager.PlayHitSound();
            _gameManager.GameOver(player.CurrentPoints);
        }
    }
}
