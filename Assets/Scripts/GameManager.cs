using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private Player _player;
    [Inject] private MenuUI _menuUI;
    [Inject] private GameUI _gameUI;
    [Inject] private GameOverUI _gameOverUI;
    [Inject] private Spawner _spawner;
    [Inject] private BonusSpawner _bonusSpawner;

    private void Start()
    {
        EventManager.Broadcast(Events.StartMovingBackgroundEvent);
    }

    public void StartGame()
    {
        EventManager.Broadcast(Events.ContinueMovementEvent);

        _menuUI.gameObject.SetActive(false);
        _gameUI.gameObject.SetActive(true);

        _player.IsFlying = true;
    }

    public void PauseGame()
    {
        EventManager.Broadcast(Events.StopMovingBackgroundEvent);
        EventManager.Broadcast(Events.StopMovementEvent);

        _player.IsFlying = false;
    }

    public void ContinueGame()
    {
        EventManager.Broadcast(Events.StartMovingBackgroundEvent);
        EventManager.Broadcast(Events.ContinueMovementEvent);

        _player.IsFlying = true;
    }

    public void GameOver(int currentScore)
    {
        PauseGame();

        _gameUI.gameObject.SetActive(false);
        _gameOverUI.gameObject.SetActive(true);
        _gameOverUI.ShowResult(currentScore);

        _player.IsFlying = false;
    }

    public void RestartGame()
    {
        _gameUI.ResetUI();
        _gameUI.gameObject.SetActive(false);
        _gameOverUI.gameObject.SetActive(false);
        _menuUI.gameObject.SetActive(true);

        _player.ResetPlayer();
        _spawner.StopSpawn(Events.StopMovementEvent);
        _bonusSpawner.StopSpawn(Events.StopMovementEvent);

        EventManager.Broadcast(Events.StartMovingBackgroundEvent);
        EventManager.Broadcast(Events.ReturnToPoolEvent);
    }
}
