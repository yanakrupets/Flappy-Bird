using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Passage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.CurrentPoints++;

            var bestScore = PlayerPrefs.GetInt(PlayerPrefsConsts.BEST_SCORE);
            bestScore = player.CurrentPoints > bestScore ? player.CurrentPoints : bestScore;
            PlayerPrefs.SetInt(PlayerPrefsConsts.BEST_SCORE, bestScore);

            var pointevent = Events.PointEvent;
            pointevent.point = 1;
            EventManager.Broadcast(pointevent);
        }
    }
}
