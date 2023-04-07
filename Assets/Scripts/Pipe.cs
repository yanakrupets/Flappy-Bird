using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            var gameOverEvent = Events.GameOverEvent;
            gameOverEvent.currentScore = player.CurrentPoints;
            EventManager.Broadcast(gameOverEvent);
        }
    }
}
